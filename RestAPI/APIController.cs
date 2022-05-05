using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class APIController<TController> : ControllerBase where TController : ControllerBase
    {
        private readonly IMediator _mediator;
        protected readonly ILogger<TController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public APIController(IMediator mediator, ILogger<TController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        /// <summary>
        /// Standard WS Response
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        protected async Task<ActionResult<APIResponse<T>>> WSResponse<T>(IRequest<T> request) where T : class
        {
            try
            {
                return Ok(APIUtiltiies.WrapReponse(StatusCodes.Status200OK, "", await _mediator.Send(request)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            await _mediator.Send(request);
        }
    }
}
