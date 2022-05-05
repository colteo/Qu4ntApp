using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.V1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class StringListController : ControllerBase
    {
        private readonly ILogger _logger;
        [HttpGet()]
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where(x => x.StartsWith("B"));
        }
    }
}
