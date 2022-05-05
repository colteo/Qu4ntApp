using Application.Abstractions.Repositories;
using Domain.Entities.Prova;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.ProvaHandlers.Queries.GetAll
{
    public class GetAllProveRequest : IRequest<IEnumerable<GetAllProveDTO>>
    {

    }

    public class GetAllProveHandler : IRequestHandler<GetAllProveRequest, IEnumerable<GetAllProveDTO>>
    {
        private readonly IProvaRepository _repository;
        private readonly ILogger<GetAllProveHandler> _logger;
        public GetAllProveHandler(IProvaRepository repository, ILogger<GetAllProveHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<GetAllProveDTO>> Handle(GetAllProveRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sei in GetAllProveHandler");
            List<Prova> prove = await _repository.GetAll();
            List<GetAllProveDTO> proveDTO = prove.Select(x => new GetAllProveDTO()
            {
                Name = x.Name,
                UpdatedOn = x.UpdatedOn != DateTime.MinValue ? x.UpdatedOn : x.CreatedOn
            }).ToList();
            return proveDTO;
        }
    }
}
