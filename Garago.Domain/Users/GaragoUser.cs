using Garago.Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Domain
{
    public class GaragoUser : IdentityUser
    {
         private GaragoUser() { }
         public GaragoUser(string name, string username, string email, string avatar, string address1, string statecode, int zipcode, string city, string oauthId="")
        {
            UserName = username;
            Name = name;
            Email = email;
            Avatar = avatar;
            Address1 = address1;
            StateCode = Enum.Parse<StateEnum>(statecode);
            Zipcode = zipcode;
            City = city;
            OAuthId = oauthId;
        }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public string PushNotificationToken { get; set; } = "";

        public string Address1 { get; set; } = "";

        public string Address2 { get; set; } = "";

        public string Address3 { get; set; } = "";

        private string _fullAddress = "";

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

        public StateEnum StateCode { get; set; }

        public int Zipcode { get; set; } = 00000;

        public string City { get; set; } = "";

        public string PurchaseHistory { get; set; } = "";

        public string MyCart { get; set; } = "";

        public string OAuthId { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
