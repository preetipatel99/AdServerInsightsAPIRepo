using AdServerInsights.DataAccess.Repository.Interface;
using AdServerInsights.ServiceLibrary.Strategies.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdServerInsights.ServiceLibrary.Strategies
{
    public class RedisAdMetricsStrategy : IAdMetricsStrategy
    {
        private readonly ICacheStrategy _cacheStrategy;

        public RedisAdMetricsStrategy(ICacheStrategy cacheStrategy)
        {
            _cacheStrategy = cacheStrategy;
        }

        public async Task<Int64> GetClicksByCampaignId(string campaignID, string tenantId)
        {
            return await _cacheStrategy.GetClicksByCampaignId(campaignID,tenantId);
        }

        public async Task<long> GetClicksByCampaignIdAndAdId(string campaignID, string AdId, string tenantId)
        {
            return await _cacheStrategy.GetClicksByCampaignIdAndAdId(campaignID, AdId,tenantId);
        }
    }

}
