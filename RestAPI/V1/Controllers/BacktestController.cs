using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace RestAPI.V1.Controllers
{
    public class BacktestController : APIController<BacktestController>
    {
        public BacktestController(IMediator mediator, ILogger<BacktestController> logger)
            : base(mediator, logger)
        {

        }

        [HttpGet("check-url-is-on")]
        public string CheckUrlIsOn()
        {
            return "OK";
        }

        [HttpPost("add-backtest")]
        public string AddBacktest(BacktestDTO dto)
        {
            int CIAO = 0;

            CIAO++;

            return "ciaooo";
        }
    }
    public class BacktestDTO
    {
        public string Name { get; set; } = string.Empty;
    }
}
