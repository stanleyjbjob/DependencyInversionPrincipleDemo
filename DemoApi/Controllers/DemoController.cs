using DependencyInversionPrincipleDemo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public DemoController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        public string Get()
        {
            return "HelloWorld";
        }
        [HttpGet("Login")]
        public string Login()
        {
            return _loginService.ValidateUser("Stanley", "3554436");
        }
    }
}
