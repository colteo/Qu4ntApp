using Application.Abstractions.Repositories;
using Domain.Entities.Strategy;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.StrategyHandlers.Queries.CountStrategies
{
    public class CountStrategiesRequest : IRequest<CountStrategiesDTO>
    {

    }

    public class CountStrategiesHandler : IRequestHandler<CountStrategiesRequest, CountStrategiesDTO>
    {
        private readonly IStrategyRepository _repository;
        private readonly ILogger<CountStrategiesHandler> _logger;
        public CountStrategiesHandler(IStrategyRepository repository, ILogger<CountStrategiesHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<CountStrategiesDTO> Handle(CountStrategiesRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<Strategy>.Filter.Empty;

            return new CountStrategiesDTO()
            {
                Strategies = await _repository.CountStrategies(filter),
                Outcomes = await _repository.CountOutcomes(filter),
            };
        }
    }
}
