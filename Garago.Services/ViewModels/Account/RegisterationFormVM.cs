using Garago.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.Account
{
    public class RegisterationFormVM
    {
        //Define a constructor function that makes email and avatar, and address only 
        public RegisterationFormVM(string email, string password, string avatar, AddressVM address, string username="")
        {
            Email = email;

            Password = password;

            Avatar = avatar;

            UserName = username;

            Address = address;
        }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public string Avatar { get; set; }
            
        public AddressVM Address { get; set; }

        public string[] Roles { get; set; }
        
        public string[] Policies { get; set; }
        }
}
