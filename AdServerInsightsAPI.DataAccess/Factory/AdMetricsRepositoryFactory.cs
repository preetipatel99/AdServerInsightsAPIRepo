using AdServerInsights.DataAccess.Factory.Interface;
using AdServerInsights.DataAccess.Repository.Interface;
namespace AdServerInsights.DataAccess.Factory
{
    public class AdMetricsRepositoryFactory : IAdMetricsRepositoryFactory
    {
        private readonly IRedisAdMetricsRepository _redisRepo;
        private readonly IBigQueryAdMetricsRepository _bigQueryRepo;

        public AdMetricsRepositoryFactory(IRedisAdMetricsRepository redisRepo, IBigQueryAdMetricsRepository bigQueryRepo)
        {
            _redisRepo = redisRepo;
            _bigQueryRepo = bigQueryRepo;
        }

        public T GetRepository<T>() where T : class
        {
            if (typeof(T) == typeof(IRedisAdMetricsRepository))
                return _redisRepo as T;

            if (typeof(T) == typeof(IBigQueryAdMetricsRepository))
                return _bigQueryRepo as T;

            throw new InvalidOperationException("Unsupported repository type.");
        }
    }



}
