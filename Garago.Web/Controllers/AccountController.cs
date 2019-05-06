using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Garago.Services.Service.Users;
using Garago.Services.ViewModels.Account;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Garago.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginFormVM loginForm)
        {
            var user = await _accountService.AttemptLogin(loginForm);
            return Ok(user);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////Social Media Logins or Third Party Login Providers//////////////////
        [HttpPost("facebook")]
        public async Task<IActionResult> LoginFacebook([FromBody] FacebookCredentialsVM fbCredentials)
        {
            var user = await _accountService.FacebookLogin(fbCredentials);
            return Ok(user);
        }


        [HttpPost("register")]
        public async Task<IActionResult> PostUser([FromBody] RegisterationFormVM registerForm)
        {

            //Define your theh info you would set towards your sesssion
            var infoToReturn = await _accountService.Register(registerForm);
            
            //Set your options for your Cookies.
            CookieOptions options = Set(1000);
            
            //Get bytes using a using statement
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(new byte[128 / 8]);
            }

            //I will hash the user's display name, then use teh sale, the hashing algorithm, iteration count, and number of bytes requested from the result.
            string hashedDisplayName = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: infoToReturn.Identity.DisplayName,
                    salt: new byte[128/8],
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8
                ));

            //Append your user to your response cookies 
            Response.Cookies.Append("user", hashedDisplayName, options);

            return Ok(infoToReturn);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return NoContent();
        }
       /// ///////////////////////////////////////////////////////////////////////////////////
       /// ///////////////////////////////////////////////////////////////////////////////////
       /// ////////////////////////////////////////////////////////////////////////////////////
        //Methods for defining and maniupulating cookies.
        public string Remove(string key)
        {
            //Delete the key argument from your resposne cookies.
            Response.Cookies.Delete(key);
            //If the key is user means that you are logging out 
            if (key == "user")
                return "Logout sucessfully!";
            //Else specify the key your just deleted 
            return $"{key} has been deleted from the response cookies.";
        }

        //SEt the CookieOptions of the session.
        public CookieOptions Set(int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(20);

            return option;
        }
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
    }
}