namespace AdServerInsights.ServiceLibrary.Services
{
    public interface IAdMetricsService
    {
        Task<Int64> GetAdClicksByCampaignId(string campaignID, string tenantId);
    }

}
