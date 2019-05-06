using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.User
{
    public class ForiegnUserVM : EntityVM
    {
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public string Link
        {
            get
            {
                return $"http://localhost:8080/users/{Id}";
            }
        }
    }
}
