using Application.Abstractions.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.StrategyHandlers.Queries.GetDistinctValues
{
    public class GetDistinctValuesRequest : IRequest<IEnumerable<string>>
    {
        public string Field { get; set; }
    }

    public class GetDistinctValuesHandler : IRequestHandler<GetDistinctValuesRequest, IEnumerable<string>>
    {
        private readonly IStrategyRepository _repository;
        private readonly ILogger<GetDistinctValuesHandler> _logger;
        public GetDistinctValuesHandler(IStrategyRepository repository, ILogger<GetDistinctValuesHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<string>> Handle(GetDistinctValuesRequest request, CancellationToken cancellationToken)
        {

            return _repository.GetDistinct(request.Field);
        }
    }
}
