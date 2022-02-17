using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDependencyInversionPrinciple
{
    public class SecurityService
    {
        public bool LoginUser(string userName, string passWord)
        {
            LoginService service = new LoginService();
            return service.ValidateUser(userName, passWord);
        }
    }
    public class LoginService
    {
        public bool ValidateUser(string userName, string passWord)
        {
            //讀取資料庫驗證使用者及密碼
            return true;
        }
    }
}
