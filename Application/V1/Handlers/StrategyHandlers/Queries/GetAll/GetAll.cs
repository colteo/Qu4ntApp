using Application.Abstractions.Repositories;
using Domain.Entities.Strategy;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.StrategyHandlers.Queries.GetAll
{
    public class GetAllRequest : IRequest<IEnumerable<Strategy>>
    {

    }

    public class GetAllHandler : IRequestHandler<GetAllRequest, IEnumerable<Strategy>>
    {
        private readonly IStrategyRepository _repository;
        private readonly ILogger<GetAllHandler> _logger;
        public GetAllHandler(IStrategyRepository repository, ILogger<GetAllHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Strategy>> Handle(GetAllRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sei in GetAllProveHandler");
            IEnumerable<Strategy> prove = await _repository.GetAll();

            return prove;
        }
    }
}
