using AdServerInsights.DataAccess.Repository.Interface;
using AdServerInsights.ServiceLibrary.Strategies;
using AdServerInsights.ServiceLibrary.Strategies.Interface;

namespace AdServerInsights.ServiceLibrary.Services
{
    public class AdMetricsService : IAdMetricsService
    {
        private readonly AdMetricsStrategyFactory _strategyFactory;
        private readonly IRedisAdMetricsRepository _redisRepository;

        public AdMetricsService(AdMetricsStrategyFactory strategyFactory, IRedisAdMetricsRepository redisRepository)
        {
            _strategyFactory = strategyFactory;
            _redisRepository = redisRepository;
        }
        public async Task<Int64> GetAdClicksByCampaignId(string campaignID, string tenantId)
        {
            var strategy = _strategyFactory.GetStrategy(true); // Fetch from Redis first
            var clicks = await strategy.GetClicksByCampaignId(campaignID, tenantId);

            if (clicks == 0)
            {
                strategy = _strategyFactory.GetStrategy(false); // Fallback to BigQuery
                clicks = await strategy.GetClicksByCampaignId(campaignID, tenantId);
            }

            return clicks;
        }
    }



}
