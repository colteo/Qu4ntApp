using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.V2.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class StringListController : Controller
    {
        [HttpGet()]
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where(x => x.StartsWith("S"));
        }
    }
}
