using AdServerInsights.ServiceLibrary.Interface;
using AdServerInsights.ServiceLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdServerInsightsAPI.Controllers
{
    [Route("api/ad")]
    [ApiController]
    public class AdMetricsController : BaseController
    {
        private readonly IAdMetricsService _adMetricsService;

        public AdMetricsController(IAdMetricsService adMetricsService, ITenantContextService tenantContextService)
            : base(tenantContextService)
        {
            _adMetricsService = adMetricsService;
        }

        [HttpGet("{campaignID}/clicks")]
        public async Task<IActionResult> GetAdClicks(string campaignID)
        {
            var clicks = await _adMetricsService.GetAdClicksByCampaignId(campaignID, TenantId);
            return Ok(clicks);
        }
    }

}
