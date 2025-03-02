namespace AdServerInsights.DataAccess.Repository.Interface
{
    public interface IBigQueryAdMetricsRepository
    {
        public Task<Int64> GetRealTimeClicksByCampaignId(string campaignId, string tenantId);
        Task<Int64> GetClicksByCampaignIdAndLookbackPeriod(string campaignID, string tenantId, TimeSpan lookbackPeriod);
    }

}
