using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_Demo_Web.Controllers
{
    [Route("Demo")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "HelloWorld";
        }
    }
}
