using Garago.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Garago.Domain.Users
{
    //Define your policies that will be set towards your roles
    public static class Policies
    {
        public const string NormalUser = Roles.NormalUser;

        public const string Buyer = Roles.Buyer;

        public const string BuyerOnly = Roles.Buyer + " Only";

        public const string Seller = Roles.Seller;

        public const string ShipperOnly = Roles.Shipper + " Only";
        
        //Shipping manager

        //Shipping Directorr

        public const string AdminOnly = Roles.Admin + " Only";

    }
}
