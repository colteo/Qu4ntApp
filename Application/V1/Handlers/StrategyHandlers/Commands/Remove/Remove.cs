using Application.Abstractions.Repositories;
using Domain;
using Domain.Entities.Strategy;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.StrategyHandlers.Commands.Remove
{
    public class RemoveStrategiesRequest : IRequest<Empty>
    {
        public HashSet<Strategy> Strategies { get; set; }
    }

    public class RemoveStrategiesHandler : IRequestHandler<RemoveStrategiesRequest, Empty>
    {
        private readonly IStrategyRepository _repository;
        private readonly ILogger<RemoveStrategiesHandler> _logger;
        public RemoveStrategiesHandler(IStrategyRepository repository, ILogger<RemoveStrategiesHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Empty> Handle(RemoveStrategiesRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<Strategy>.Filter.Empty;
            foreach (Strategy strategy in request.Strategies)
            {
                filter = Builders<Strategy>.Filter.Eq(nameof(Strategy.Id), strategy.Id);
                _repository.Remove(filter);
            }
            _repository.Remove(filter);
            return new Empty();
        }
    }
}
