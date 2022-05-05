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

namespace Application.V1.Handlers.StrategyHandlers.Queries.GetById
{
    public class GetStrategyByIdRequest : IRequest<Strategy>
    {
        public string Id { get; set; }
    }

    public class GetStrategyByIdHandler : IRequestHandler<GetStrategyByIdRequest, Strategy>
    {
        private readonly IStrategyRepository _repository;
        private readonly ILogger<GetStrategyByIdHandler> _logger;
        public GetStrategyByIdHandler(IStrategyRepository repository,
            ILogger<GetStrategyByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Strategy> Handle(GetStrategyByIdRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<Strategy>.Filter.Eq(nameof(Strategy.Id), request.Id);
            return await _repository.Get(filter);
        }
    }
}
