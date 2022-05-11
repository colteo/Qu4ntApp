using Application.Abstractions.Repositories;
using Domain;
using Domain.Entities.Strategy;
using Domain.Enum;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.StrategyHandlers.Commands.AddOutcome
{
    public class AddOutcomeRequest : IRequest<Empty>
    {
        public AddOutcomeDTO Dto { get; set; }
    }

    public class AddOutcomeHandler : IRequestHandler<AddOutcomeRequest, Empty>
    {
        private readonly IStrategyRepository _repository;
        private readonly ILogger<AddOutcomeHandler> _logger;
        public AddOutcomeHandler(IStrategyRepository repository, ILogger<AddOutcomeHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Empty> Handle(AddOutcomeRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<Strategy>.Filter.Eq(nameof(Strategy.Id), request.Dto.StrategyId);

            Outcome outcome = new Outcome()
            {
                Id = await _repository.CountOutcomes(filter) + 1,
                Trade = new Trade(request.Dto.TradeId, 
                    request.Dto.TradePrice,
                    (PositionType)Enum.Parse(typeof(PositionType), request.Dto.TradeType, true),
                    request.Dto.TradeDatetime,
                    new Candle(request.Dto.TradeStreamDatetime, request.Dto.TradeStreamAsk, request.Dto.TradeStreamBid)),
                Order = new Order(request.Dto.OrderId,
                    request.Dto.OrderParentId,
                    (OrderType)Enum.Parse(typeof(OrderType), request.Dto.OrderType, true),
                    request.Dto.OrderPrice,
                    new Candle(request.Dto.OrderStreamDatetime, request.Dto.OrderStreamAsk, request.Dto.OrderStreamBid)),
                InitialCash = request.Dto.InitialCash,
                FinalCash = request.Dto.FinalCash
            };

            var update = Builders<Strategy>.Update.Push(nameof(Strategy.Outcomes), outcome);

            await _repository.Update(filter, update);
            return new Empty();
        }
    }
}
