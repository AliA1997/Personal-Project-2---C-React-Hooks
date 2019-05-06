using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Garago.Instructure
{
    public static class AuthUtility
    {
        private static byte[] salt = new byte[128 / 8];
        public static string HashPassword(string password)
        {

            //Generate a secure 128 bit salt.
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            //Hash   the password by passing the string to hash, salt, hash algorithm, iterationCount, and number of bytes.
            string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256/8
                ));
            return passwordHash;
        }

        //Have function that will delete a session.
        public static void Delete(string key, HttpResponse response)
        {
            response.Cookies.Delete(key);
            return;
        }

        //Have a function that will create your cookie by passing a expire time argument which is the amount of time before the session expires.
        public static CookieOptions SetOptions(int? expireTime, HttpResponse response)
        {
            CookieOptions cookieOptions = new CookieOptions();

            ///If the expireTime is not null set your Session.ExpireTime to your expireTime argument.
            if (expireTime.HasValue)
                cookieOptions.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                cookieOptions.Expires = DateTime.Now.AddMilliseconds(20);

            return cookieOptions;
        }
    }
}
