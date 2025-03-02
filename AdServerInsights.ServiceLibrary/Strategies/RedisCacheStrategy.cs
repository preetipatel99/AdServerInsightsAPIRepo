using AdServerInsights.DataAccess.Repository.Interface;
using AdServerInsights.ServiceLibrary.Strategies.Interface;
using StackExchange.Redis;
namespace AdServerInsights.ServiceLibrary.Strategies
{
    public class RedisCacheStrategy : ICacheStrategy
    {
        private readonly IRedisAdMetricsRepository _redisRepository;

        public RedisCacheStrategy(IRedisAdMetricsRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public async Task<Int64> GetClicksByCampaignId(string campaignID, string tenantId)
        {
            var clicks = await _redisRepository.GetRealTimeClicksByCampaignId(campaignID, tenantId);
            return clicks > 0 ? Convert.ToInt64(clicks) : 0;
        }

        public async Task<Int64> GetClicksByCampaignIdAndAdId(string campaignId, string AdId, string tenantId)
        {
            var clicks = await _redisRepository.GetRealTimeClicksByCampaignIdAndAdId(campaignId, AdId, tenantId);
            return clicks > 0 ? Convert.ToInt64(clicks) : 0;
        }
    }



}
