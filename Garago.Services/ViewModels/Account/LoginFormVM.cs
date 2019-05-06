using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Garago.Services.ViewModels.Account
{
    public class LoginFormVM
    {
        [Required(ErrorMessage = "Require email to login.")]
        public string DisplayName { get; set; }
        
        [Required(ErrorMessage ="Require a password.")]
        public string Password { get; set; }
    }
}
