using Microsoft.AspNetCore.Mvc;

namespace SuperApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string api)
        {
            // TODO: Add logic

            return "value";
        }

    }
}