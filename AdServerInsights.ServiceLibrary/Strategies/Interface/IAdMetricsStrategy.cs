using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdServerInsights.ServiceLibrary.Strategies.Interface
{
    public interface IAdMetricsStrategy
    {
        Task<Int64> GetClicksByCampaignId(string campaignID, string tenantId);
    }

}
