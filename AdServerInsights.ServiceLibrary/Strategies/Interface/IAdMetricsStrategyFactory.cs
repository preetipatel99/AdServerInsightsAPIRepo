using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdServerInsights.ServiceLibrary.Strategies.Interface
{
    public interface IAdMetricsStrategyFactory
    {
        IAdMetricsStrategy GetStrategy(bool useRealTime);
    }
}
