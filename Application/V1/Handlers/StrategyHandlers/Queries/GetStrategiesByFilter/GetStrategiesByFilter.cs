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

namespace Application.V1.Handlers.StrategyHandlers.Queries.GetStrategiesByFilter
{
    public class GetStrategiesByFilterRequest : IRequest<IEnumerable<Strategy>>
    {
        public GetStrategiesByFilterForm Form { get; set; }
    }

    public class GetStrategiesByFilterHandler : IRequestHandler<GetStrategiesByFilterRequest, IEnumerable<Strategy>>
    {
        private readonly IStrategyRepository _repository;
        private readonly ILogger<GetStrategiesByFilterHandler> _logger;
        public GetStrategiesByFilterHandler(IStrategyRepository repository,
            ILogger<GetStrategiesByFilterHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Strategy>> Handle(GetStrategiesByFilterRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<Strategy>.Filter.Eq(nameof(Strategy.Type), request.Form.Type);
            if (!String.IsNullOrEmpty(request.Form.Name))
            {
                filter &= Builders<Strategy>.Filter.Eq(nameof(Strategy.Name), request.Form.Name);
            }
            if (request.Form.CreatedOn is not null)
            {
                DateTime createdOnStart = request.Form.CreatedOn ?? DateTime.Now;
                DateTime createdOnEnd = createdOnStart.AddDays(1);
                filter &= Builders<Strategy>.Filter.Gte(nameof(Strategy.CreatedOn), createdOnStart.ToLocalTime());
                filter &= Builders<Strategy>.Filter.Lt(nameof(Strategy.CreatedOn), createdOnEnd.ToLocalTime());
            }
            if (request.Form.Instruments.Count() > 0)
            {
                filter &= Builders<Strategy>.Filter.In(nameof(Strategy.Instrument), request.Form.Instruments);
            }
            if (request.Form.Granularities.Count() > 0)
            {
                filter &= Builders<Strategy>.Filter.In(nameof(Strategy.Granularity), request.Form.Granularities);
            }
            var sort = Builders<Strategy>.Sort.Descending(request.Form.OrderBy);
            var limit = request.Form.Limit;
            return await _repository.Get(filter, sort, limit);
        }
    }
}
