using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.Account
{
    public class FacebookCredentialsVM
    {
        public string AccessToken { get; set; }
        public int DataAccessExpirationTime { get; set; }
        public int ExpiresIn { get; set; }
        public int ReauthorizeRequiredIn { get; set; }
        public string SignedRequest { get; set; }
        public string UserId { get; set; }
    }
}
