using Application.V1.Handlers.ProvaHandlers.Commands;
using Application.V1.Handlers.ProvaHandlers.Commands.Create;
using Application.V1.Handlers.ProvaHandlers.Commands.Update;
using Application.V1.Handlers.ProvaHandlers.Queries;
using Application.V1.Handlers.ProvaHandlers.Queries.GetAll;
using Application.V1.Handlers.ProvaHandlers.Queries.GetById;
using Domain.Entities.Prova;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.V1.Controllers
{
    [ApiVersion("1.0")]
    public class ProveController : APIController<ProveController>
    {
        public ProveController(IMediator mediator, ILogger<ProveController> logger)
            : base(mediator, logger)
        {

        }

        [HttpGet()]
        public async Task<ActionResult<APIResponse<IEnumerable<GetAllProveDTO>>>> GetAll() 
            => await WSResponse(new GetAllProveRequest());


        [HttpGet("get-by-id")]
        public async Task<ActionResult<APIResponse<GetProvaByIdDTO>>> Get(string id) 
            => await WSResponse(new GetProvaByIdRequest() { Id = id });

        [HttpPost]
        public async Task<ActionResult<APIResponse<Prova>>> Post(CreateProvaDTO dto) 
            => await WSResponse(new ProvaCreateRequest() { Prova = dto });
        
        [HttpPut]
        public async Task<ActionResult<APIResponse<Prova>>> Put(UpdateProvaDTO dto) 
            => await WSResponse(new UpdateCreateRequest() { Prova = dto });
    }
}
