using AdServerInsights.ServiceLibrary.Strategies.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdServerInsights.ServiceLibrary.Strategies
{
    public class AdMetricsStrategyFactory:IAdMetricsStrategyFactory
    {
        private readonly RedisAdMetricsStrategy _redisStrategy;
        private readonly BigQueryAdMetricsStrategy _bigQueryStrategy;

        public AdMetricsStrategyFactory(RedisAdMetricsStrategy redisStrategy, BigQueryAdMetricsStrategy bigQueryStrategy)
        {
            _redisStrategy = redisStrategy;
            _bigQueryStrategy = bigQueryStrategy;
        }

        public IAdMetricsStrategy GetStrategy(bool useRealTime)
        {
            return useRealTime ? _redisStrategy : _bigQueryStrategy;
        }
    }

}
