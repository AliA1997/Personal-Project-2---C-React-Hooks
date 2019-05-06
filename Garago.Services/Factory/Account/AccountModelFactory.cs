using Garago.Domain;
using Garago.Services.ViewModels.Account;
using Garago.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.Factory.Account
{
    public static class AccountModelFactory
    {
        public static LoginReturnVM CreateViewModel(object accessToken, string expiresIn, UserVM userInfo)
        {
            return new LoginReturnVM()
            {
                AccessToken = accessToken,
                ExpiresIn = expiresIn,
                Identity = userInfo
            };
        }

        public static GaragoUser CreateDomainModel(RegisterationFormVM registerUser)
        {
            return new GaragoUser(
                    null,
                    registerUser.UserName,
                    registerUser.Email,
                    registerUser.Email,
                    registerUser.Address.Address1,
                    registerUser.Address.StateCode,
                    registerUser.Address.Zipcode,
                    registerUser.Address.City
                );

        }
        
    }
}
