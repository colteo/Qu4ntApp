using Domain.Entities.Strategy;
using MongoDB.Driver;

namespace Application.Abstractions.Repositories
{
    public interface IStrategyRepository
    {
        Task<IEnumerable<Strategy>> GetAll();
        Task<IEnumerable<Strategy>> Get(FilterDefinition<Strategy> filter, SortDefinition<Strategy> sort, int limit);
        Task<Strategy> Get(FilterDefinition<Strategy> filter);
        Task<Strategy> Add(Strategy strategy);
        Task Update(FilterDefinition<Strategy> filter, UpdateDefinition<Strategy> update);
        Task<long> CountStrategies(FilterDefinition<Strategy> filter);
        Task<long> CountOutcomes(FilterDefinition<Strategy> filter);
        IEnumerable<string> GetDistinct(string field);
        Task Remove(FilterDefinition<Strategy> filter);
    }
}
