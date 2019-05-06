using Garago.Services.ViewModels.Account;
using Garago.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Services.Service.Users
{
    public interface IAccountService
    {
        Task<LoginReturnVM> Register(RegisterationFormVM registerForm);
        Task<LoginReturnVM> AttemptLogin(LoginFormVM loginForm);
        Task<LoginReturnVM> FacebookLogin(FacebookCredentialsVM fbCreds);
        Task Logout();
        object GenerateJwtToken(UserVM user);
    }
}
