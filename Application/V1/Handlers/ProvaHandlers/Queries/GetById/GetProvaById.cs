using Application.Abstractions.Repositories;
using AutoMapper;
using Domain.Entities.Prova;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.V1.Handlers.ProvaHandlers.Queries.GetById
{
    public class GetProvaByIdRequest : IRequest<GetProvaByIdDTO>
    {
        public string Id { get; set; }
    }

    public class GetProvaByIdHandler : IRequestHandler<GetProvaByIdRequest, GetProvaByIdDTO>
    {
        private readonly IProvaRepository _repository;
        private readonly ILogger<GetProvaByIdHandler> _logger;
        public GetProvaByIdHandler(IProvaRepository repository, 
            ILogger<GetProvaByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<GetProvaByIdDTO> Handle(GetProvaByIdRequest request, CancellationToken cancellationToken)
        {
            var filter = Builders<Prova>.Filter.Eq(nameof(Prova.Id), request.Id);
            Prova prova = await _repository.Get(filter);
            GetProvaByIdDTO dto = new GetProvaByIdDTO
            {
                Name = prova.Name
            };
            return dto;
        }
    }
}
