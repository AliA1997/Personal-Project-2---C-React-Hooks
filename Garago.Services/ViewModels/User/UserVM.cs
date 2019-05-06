using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Services.ViewModels.User
{
    public class UserVM : EntityVM
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Avatar { get; set; }
        public string PushNotificationToken { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        private string _fullAddress;

        public string FullAddress
        {
            get
            {
                return _fullAddress;
            }
            set
            {
                _fullAddress = $"{Address1} #{Zipcode} {City}, {StateCode}";
            }
        }
        

        public string StateCode { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string PurchaseHistory { get; set; }
        public string MyCart { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get;set; }
    }
}
