using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garago.Web.Security
{
    public interface ISecurityManager
    {
        string Name { get; }

        //For loading policies pass a authorization options.
        void loadAuthorization(AuthorizationOptions options);
    }
}
