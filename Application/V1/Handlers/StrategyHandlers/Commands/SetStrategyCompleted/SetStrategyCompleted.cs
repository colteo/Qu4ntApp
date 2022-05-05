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

namespace Application.V1.Handlers.StrategyHandlers.Commands.SetStrategyCompleted
{
    public class SetStrategyCompletedRequest : IRequest<Empty>
    {
        public SetStrategyCompletedDTO Dto { get; set; }
    }

    public class SetStrategyCompletedHandler : IRequestHandler<SetStrategyCompletedRequest, Empty>
    {
        private readonly IStrategyRepository _repository;
        private readonly ILogger<SetStrategyCompletedHandler> _logger;
        public SetStrategyCompletedHandler(IStrategyRepository repository, ILogger<SetStrategyCompletedHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Empty> Handle(SetStrategyCompletedRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<Strategy>.Filter.Eq(nameof(Strategy.Id), request.Dto.StrategyId);

            Strategy strategy = await _repository.Get(filter);
            strategy.FinalCash = request.Dto.FinalCash;
            strategy.Completed = true;
            strategy.CalcStats();

            var update = Builders<Strategy>.Update
                .Set(nameof(Strategy.FinalCash), strategy.FinalCash);
            await _repository.Update(filter, update);

            update = Builders<Strategy>.Update
                .Set(nameof(Strategy.Completed), strategy.Completed);
            await _repository.Update(filter, update);

            update = Builders<Strategy>.Update
                .Set(nameof(Strategy.Stats), strategy.Stats);
            await _repository.Update(filter, update);

            //var update = Builders<Strategy>.Update
            //    .Set(nameof(Strategy.FinalCash), strategy.FinalCash)
            //    .AddToSet(nameof(Strategy.Completed), strategy.Completed)
            //    .AddToSet(nameof(Strategy.Stats), strategy.Stats);
            //await _repository.Update(filter, update);

            return new Empty();
        }
    }
}
