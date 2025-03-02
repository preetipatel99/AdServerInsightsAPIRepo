using System.IdentityModel.Tokens.Jwt;
using AdServerInsights.ServiceLibrary;
using AdServerInsights.ServiceLibrary.Interface;

namespace AdServerInsightsAPI.Middleware
{  
    public class TenantValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITenantContextService _tenantContextService;

        public TenantValidationMiddleware(RequestDelegate next, ITenantContextService tenantContextService)
        {
            _next = next;
            _tenantContextService = tenantContextService;
        }

        public async Task Invoke(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: Missing Bearer Token");
                return;
            }

            var token = authHeader.Substring("Bearer ".Length);
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized: Invalid Token");
                return;
            }

            // 🔹 Extract Tenant ID from JWT Claims
            var tenantIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "tenant_id")?.Value;

            if (string.IsNullOrEmpty(tenantIdClaim))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Forbidden: Tenant ID Missing in Token");
                return;
            }

            // 🔹 Store Tenant ID in TenantContext (Centralized)
            _tenantContextService.SetTenantId(tenantIdClaim);

            await _next(context);
        }
    }

}
