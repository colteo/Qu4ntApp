using MediatR;
using Microsoft.Extensions.Logging;
using Domain.Entities.Prova;
using Application.Abstractions.Repositories;

namespace Application.V1.Handlers.ProvaHandlers.Commands.Create
{
    public class ProvaCreateRequest : IRequest<Prova>
    {
        public CreateProvaDTO Prova { get; set; }
    }

    public class ProvaCreateHandler : IRequestHandler<ProvaCreateRequest, Prova>
    {
        private readonly IProvaRepository _repository;
        private readonly ILogger<ProvaCreateHandler> _logger;
        public ProvaCreateHandler(IProvaRepository repository, ILogger<ProvaCreateHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Prova> Handle(ProvaCreateRequest request, CancellationToken cancellationToken)
        {
            return await _repository.Add(new Prova(request.Prova.Name));
        }
    }
}
