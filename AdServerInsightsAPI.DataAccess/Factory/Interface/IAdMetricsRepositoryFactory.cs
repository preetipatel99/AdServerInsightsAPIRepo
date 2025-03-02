using AdServerInsights.DataAccess.Repository.Interface;

namespace AdServerInsights.DataAccess.Factory.Interface
{
    public interface IAdMetricsRepositoryFactory
    {
        T GetRepository<T>() where T : class;
    }


}
