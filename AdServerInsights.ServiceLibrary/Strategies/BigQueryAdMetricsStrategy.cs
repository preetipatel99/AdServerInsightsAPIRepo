using AdServerInsights.DataAccess.Repository.Interface;
using AdServerInsights.ServiceLibrary.Strategies.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdServerInsights.ServiceLibrary.Strategies
{
    public class BigQueryAdMetricsStrategy : IAdMetricsStrategy
    {
        private readonly IBigQueryAdMetricsRepository _bigQueryRepository;

        public BigQueryAdMetricsStrategy(IBigQueryAdMetricsRepository bigQueryRepository)
        {
            _bigQueryRepository = bigQueryRepository;
        }

        public async Task<Int64> GetClicksByCampaignId(string campaignID, string tenantId)
        {
            return await _bigQueryRepository.GetRealTimeClicksByCampaignId(campaignID, tenantId);
        }
    }

}
