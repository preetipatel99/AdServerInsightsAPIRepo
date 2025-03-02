namespace AdServerInsights.ServiceLibrary.Strategies.Interface
{
    public interface ICacheStrategy
    {
        Task<long> GetClicksByCampaignId(string campaignId, string tenantId);
        Task<long> GetClicksByCampaignIdAndAdId(string campaignId, string AdId, string tenantId);
    }

}
