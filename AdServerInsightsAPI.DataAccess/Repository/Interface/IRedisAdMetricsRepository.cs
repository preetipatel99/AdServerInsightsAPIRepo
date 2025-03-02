namespace AdServerInsights.DataAccess.Repository.Interface
{
    public interface IRedisAdMetricsRepository
    {
        public Task<Int64> GetRealTimeClicksByCampaignId(string campaignId, string tenantId);
        Task<Int64> GetRealTimeClicksByCampaignIdAndAdId(string campaignID, string AdId, string tenantId);
    }

}
