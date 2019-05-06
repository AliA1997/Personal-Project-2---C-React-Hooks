using Garago.Services.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.Account
{
    //Define a class that is returned when a user logs in using the sign in manager.
    public class LoginReturnVM
    {
        //Have a accessToken for each user logged in.
        public object AccessToken { get; set; }
        //Also have the time it's expires 
        public string ExpiresIn { get; set; }
        //Define a view model for containing all the specified user's data.
        public UserVM Identity { get; set; }
    }
}
