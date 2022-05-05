using Application.Abstractions.Repositories;
using Domain.Entities.Prova;
using Domain.Entities.Strategy;
using MongoDB.Driver;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StrategyRepository : IStrategyRepository
    {
        private readonly StrategyDbContext _context;
        public StrategyRepository(StrategyDbContext context)
        {
            _context = context;
        }
        public async Task<Strategy> Get(FilterDefinition<Strategy> filter)
        {
            return _context.Strategies.Find(filter).FirstOrDefault();
        }
        public async Task<Strategy> Add(Strategy strategy)
        {
            _context.Strategies.InsertOne(strategy);
            return strategy;
        }

        public async Task Update(FilterDefinition<Strategy> filter, UpdateDefinition<Strategy> update)
        {
            var result = _context.Strategies.UpdateOne(filter, update);
        }

        public async Task<long> CountStrategies(FilterDefinition<Strategy> filter)
        {
            return _context.Strategies.CountDocuments(filter);
        }

        public async Task<long> CountOutcomes(FilterDefinition<Strategy> filter)
        {
            var result = _context.Strategies
                .Aggregate()
                .Match(filter)
                .Unwind(x => x.Outcomes)
                .Count()
                .FirstOrDefault();

            return result is not null ? result.Count : 0;
        }

        public async Task<IEnumerable<Strategy>> GetAll()
        {
            return _context.Strategies.Find(Builders<Strategy>.Filter.Empty).ToList();
        }

        public IEnumerable<string> GetDistinct(string field)
        {
            return _context.Strategies.Distinct<string>(field, FilterDefinition<Strategy>.Empty).ToList<string>();
        }

        public async Task<IEnumerable<Strategy>> Get(FilterDefinition<Strategy> filter, SortDefinition<Strategy> sort, int limit)
        {
            return _context.Strategies
                .Find(filter)
                .Sort(sort)
                .Limit(limit)
                .ToList();
        }

        public async Task Remove(FilterDefinition<Strategy> filter)
        {
            _context.Strategies.DeleteMany(filter);
        }
    }
}
