using Application.V1.Handlers.StrategyHandlers.Commands.AddOutcome;
using Application.V1.Handlers.StrategyHandlers.Commands.Create;
using Application.V1.Handlers.StrategyHandlers.Commands.SetStrategyCompleted;
using Application.V1.Handlers.StrategyHandlers.Queries.GetAll;
using Domain.Entities.Strategy;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.V1.Controllers
{
    public class StrategyController : APIController<StrategyController>
    {
        public StrategyController(IMediator mediator, ILogger<StrategyController> logger)
            : base(mediator, logger)
        {

        }

        [HttpGet("check-url-is-on")]
        public string CheckUrlIsOn()
        {
            return "OK";
        }

        [HttpPost("add-outcome")]
        public async void AddOutcome(AddOutcomeDTO dto)
            => await WSResponse(new AddOutcomeRequest() { Dto = dto });

        [HttpPost("add-strategy")]
        public async Task<ActionResult<APIResponse<Strategy>>> AddStrategy(CreateStrategyDTO dto)
            => await WSResponse(new CreateStrategyRequest() { Dto = dto });

        [HttpPost("set-strategy-completed")]
        public async void SetFinalCash(SetStrategyCompletedDTO dto)
        {
            await WSResponse(new SetStrategyCompletedRequest() { Dto = dto });
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse<IEnumerable<Strategy>>>> GetAll()
            => await WSResponse(new GetAllRequest());
            
    }
}
