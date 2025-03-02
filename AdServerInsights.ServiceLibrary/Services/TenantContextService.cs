using AdServerInsights.ServiceLibrary.Interface;

namespace AdServerInsights.ServiceLibrary.Services
{
    public class TenantContextService : ITenantContextService
    {
        public string TenantId { get; private set; } = string.Empty;

        public void SetTenantId(string tenantId)
        {
            TenantId = tenantId;
        }
    }

}
