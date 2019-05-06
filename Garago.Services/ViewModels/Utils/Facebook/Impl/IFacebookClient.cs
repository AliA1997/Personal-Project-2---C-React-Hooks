using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Services.ViewModels.Utils.Facebook.Impl
{
    public interface IFacebookClient
    {
        //GEt data for the user  pass an access token endpont, and arguments to hit the facebook api server.
        Task<object> GetAsync(string accessToken, string endpoint, string args = null);
        Task PostAsync(string accessToken, string endpoint, object data, string args = null);
    }
}
