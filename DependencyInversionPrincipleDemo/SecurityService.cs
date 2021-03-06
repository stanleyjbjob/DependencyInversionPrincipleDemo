using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrincipleDemo
{
    public class SecurityService
    {
        private readonly ILoginService _loginService;
        public SecurityService(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public bool LoginUser(string userName, string passWord)
        {
            return _loginService.ValidateUser(userName, passWord);
        }
    }
    public class LoginService : ILoginService
    {
        public bool ValidateUser(string userName, string passWord)
        {
            throw new NotImplementedException();
        }
    }
}
