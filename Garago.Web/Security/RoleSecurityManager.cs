using Garago.Domain.User;
using Garago.Domain.Users;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Garago.Web.Security
{
    public class RoleSecurityManager : ISecurityManager
    {
        public string Name { get; } = "Role Security Manager";

        public void loadAuthorization(AuthorizationOptions options)
        {
            //When adding policies use the authorizationOptions addPolicy method that will take a policy and a lambda
            options.AddPolicy(Policies.NormalUser,
                policy => {
                    policy.RequireAssertion(context =>
                         context.User.HasClaim(JwtRegisteredClaimNames.Typ, Roles.NormalUser)
                    );
                });

            options.AddPolicy(Policies.AdminOnly,
                policy => policy.RequireClaim(JwtRegisteredClaimNames.Typ, Roles.Admin));

            
            options.AddPolicy(Policies.Buyer,
                policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(JwtRegisteredClaimNames.Typ, Roles.Buyer)));

            options.AddPolicy(Policies.BuyerOnly,
                policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(JwtRegisteredClaimNames.Typ, Roles.Buyer)));

            options.AddPolicy(Policies.Seller,
                policy => policy.RequireAssertion(context =>
                   context.User.HasClaim(JwtRegisteredClaimNames.Typ, Roles.Seller)));

            options.AddPolicy(Policies.ShipperOnly,
                policy => policy.RequireAssertion(context =>
                    context.User.HasClaim(JwtRegisteredClaimNames.Typ, Roles.Shipper)));
        }
    }
}
