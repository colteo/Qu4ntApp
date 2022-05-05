using Application.Abstractions.Repositories;
using Domain.Entities.Strategy;
using Domain.Enum;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.StrategyHandlers.Commands.Create
{
    public class CreateStrategyRequest : IRequest<Strategy>
    {
        public CreateStrategyDTO Dto { get; set; }
    }

    public class CreateStrategyHandler : IRequestHandler<CreateStrategyRequest, Strategy>
    {
        private readonly IStrategyRepository _repository;
        private readonly ILogger<CreateStrategyHandler> _logger;
        public CreateStrategyHandler(IStrategyRepository repository, ILogger<CreateStrategyHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Strategy> Handle(CreateStrategyRequest request, CancellationToken cancellationToken)
        {
            List<Meta> meta = new List<Meta>();
            foreach (var item in request.Dto.Meta)
            {
                meta.Add(new Meta(item.Key, item.Value.ToString()));
            }

            return await _repository.Add(new Strategy()
            {
                Type = (StrategyType)Enum.Parse(typeof(StrategyType), request.Dto.Type, true),
                Name = request.Dto.Name,
                Meta = meta,
                Instrument = request.Dto.Instrument,
                Granularity = request.Dto.Granularity,
                Start = request.Dto.Start,
                End = request.Dto.End,
                InitialCash = request.Dto.InitialCash,
                Leverage = request.Dto.Leverage,
            });
        }
    }
}
