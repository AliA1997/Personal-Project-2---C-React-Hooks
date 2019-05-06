using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Domain.User
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Shipper = "Shipper";
        public const string Buyer = "Buyer";
        public const string Seller = "Seller";
        public const string NormalUser = "Normal User";
        public static string[] All = new string[]
        {
                Admin,
                Shipper,
                NormalUser,
                Buyer,
                Seller
        };
    }
}
