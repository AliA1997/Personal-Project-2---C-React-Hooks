using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.Account
{
    //Define you OAuthREgistrationForm model which would be used to register user based on oauth model.
    public class OAuthRegisterationFormVM
    {
        //Define your OAuthId
        public string Sub { get; set; }

        public string Nickname { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }


    }
}
