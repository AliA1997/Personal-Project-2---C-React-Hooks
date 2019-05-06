using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.User
{
    public class UserItemVM : EntityVM
    {
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Link
        {
            get
            {
                return $"http://localhost:8080/users/{Id}";
            }
        }
    }
}
