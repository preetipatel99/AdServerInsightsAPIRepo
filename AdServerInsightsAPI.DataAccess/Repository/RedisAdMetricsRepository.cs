using AdServerInsights.DataAccess.Repository.Interface;
using StackExchange.Redis;

namespace AdServerInsights.DataAccess.Repository
{
    public class RedisAdMetricsRepository : IRedisAdMetricsRepository
    {
        private readonly IDatabase _redis;

        public RedisAdMetricsRepository(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }

        // Fetch real-time clicks from Redis
        public async Task<Int64> GetRealTimeClicksByCampaignId(string campaignID, string tenantId)
        {
            var clicks = await _redis.StringGetAsync($"clicks:{tenantId}_{campaignID}");
            return clicks.HasValue ? Convert.ToInt64(clicks) : 0;
        }

        public async Task<long> GetRealTimeClicksByCampaignIdAndAdId(string campaignID, string AdId, string tenantId)
        {
            var clicks = await _redis.StringGetAsync($"clicks:{tenantId}_{campaignID}_{AdId}");
            return clicks.HasValue ? Convert.ToInt64(clicks) : 0;
        }
    }

}
