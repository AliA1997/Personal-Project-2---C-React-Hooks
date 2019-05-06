using Garago.Services.ViewModels.Utils.Facebook.Impl;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Services.ViewModels.Utils.Facebook
{
    public class FacebookClient : IFacebookClient
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;

        public FacebookClient(IConfiguration configuration)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://graph.facebook.com/v3.2/")
            };

            //Add a default header to your httpClient private variables.
            //Which will by default accept a json type
            //Use .Accept to have access to request headers
            //Use .Add to add a new request header
            //new MediaTypeWithQualityHeaderValue  to specify header to application/json
            _httpClient.DefaultRequestHeaders
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _configuration = configuration;
        }

        public async Task<object> GetAsync(string accessToken, string endpoint, string args = null)
        {
            var appsecret = _configuration["FBCreds:Secret"];
            var appsecret_root = FaceBookSecret(accessToken, appsecret);
            var response = await _httpClient.GetAsync($"{endpoint}?access_token={accessToken}&appsecret_root={appsecret_root}&{args}");
            if (!response.IsSuccessStatusCode)
                //If the response is not successful return the default generic type.
                return default(object);
            //Read content from response.
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }

        public async Task PostAsync(string accessToken, string endpoint, object data, string args = null)
        {
            var appsecret = _configuration["FBCreds:Secret"];
            var appsecret_root = FaceBookSecret(accessToken, appsecret);
            var payload = GetPayload(data);
            await _httpClient.PostAsync($"{endpoint}?access_token={accessToken}&appsecret_root={appsecret_root}&{args}", payload);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        //Define a internal class method that will be responsible for generating a facebook appsecret 
        private static string FaceBookSecret(string content, string key)
        {
            //NOw assign bytes for your keys.
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            //Then assign bytes for your messages.
            byte[] messageBytes = Encoding.UTF8.GetBytes(content);
            //Have a array of bytes for when you hash you message.
            byte[] hash;
            //Have using statement that will dispose a instance of a HMACSHA256 hasher
            using (HMACSHA256 hmacsha256 = new HMACSHA256(keyBytes))
            {
                hash = hmacsha256.ComputeHash(messageBytes);
            }
            //Now build your string that will be your hashed appsecret_proof.
            StringBuilder sbHash = new StringBuilder();
            //Now loop through the array of characters and append each character formatted as a Base16 string.
            for (int i = 0; i < hash.Length; i++)
            {
                sbHash.Append(hash[i].ToString("x2"));
            }
            //Then return the string hashed.
            return sbHash.ToString();
        }
    }

}
