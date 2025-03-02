using AdServerInsights.ServiceLibrary.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AdServerInsightsAPI.Controllers
{

    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ITenantContextService _tenantContextService;

        protected BaseController(ITenantContextService tenantContextService)
        {
            _tenantContextService = tenantContextService;
        }

        protected string TenantId => _tenantContextService.TenantId;
    }

}
