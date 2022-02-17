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
        public string LoginUser(string userName, string passWord)
        {
            return _loginService.ValidateUser(userName, passWord);
        }
    }
    public class LoginService : ILoginService
    {
        public string ValidateUser(string userName, string passWord)
        {
            return "帳號密碼驗證(明碼):" + userName;
        }
    }
    public class EncyptLoginService : ILoginService
    {
        public string ValidateUser(string userName, string passWord)
        {
            return "帳號密碼驗證(加密):" + userName;
        }
    }
}
