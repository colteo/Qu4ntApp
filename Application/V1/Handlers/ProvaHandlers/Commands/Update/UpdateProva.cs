using Application.Abstractions.Repositories;
using Domain.Entities.Prova;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Application.V1.Handlers.ProvaHandlers.Commands.Update
{
    public class UpdateCreateRequest : IRequest<Prova>
    {
        public UpdateProvaDTO Prova { get; set; }
    }

    public class UpdateCreateHandler : IRequestHandler<UpdateCreateRequest, Prova>
    {
        private readonly IProvaRepository _repository;
        private readonly ILogger<UpdateCreateHandler> _logger;
        public UpdateCreateHandler(IProvaRepository repository, ILogger<UpdateCreateHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Prova> Handle(UpdateCreateRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<Prova>.Filter.Eq(nameof(Prova.Id), request.Prova.Id);
            var update = Builders<Prova>.Update
                .Set(nameof(Prova.Name), request.Prova.Name)
                .Set(nameof(Prova.UpdatedOn), DateTime.UtcNow);

            return await _repository.Update(filter, update);
        }
    }
}
