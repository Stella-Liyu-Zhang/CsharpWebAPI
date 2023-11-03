using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
        [HttpPost]
        public IActionResult Post(JsonObject payload)
        {
            //can be exposed some attack because we didn't validate the payload
            return Ok(payload);
        }
    }
}
