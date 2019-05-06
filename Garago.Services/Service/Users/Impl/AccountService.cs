using Garago.Data.Repos;
using Garago.Data.Repos.Users.Impl;
using Garago.Domain;
using Garago.Domain.User;
using Garago.Domain.Users;
using Garago.Services.Factory.Account;
using Garago.Services.Factory.User;
using Garago.Services.ViewModels.Account;
using Garago.Services.ViewModels.User;
using Garago.Services.ViewModels.Utils.Facebook;
using Garago.Services.ViewModels.Utils.Facebook.Impl;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Services.Service.Users.Impl
{
    public class AccountService : IAccountService
    {
        //Use the sign in manager to sign in users from Microsoft.AspNetCore.Identity
        //Also pass your Generic user entity type that will be logging into.
        private SignInManager<GaragoUser> _signInManager;
        //Define a userManager for registering users.
        private UserManager<GaragoUser> _userManager;
        //Also use the configuration object to be used for expire time when generating jwt tokens.
        private IConfiguration _configuration;
        //Use a Configuration
        //Also use the userRepo to get the user's information using the display name which can be a email or userName
        private IUsersRepo _userRepo;
        /// <summary>
        /// Define your facebook client that will be responsible for retrieving the user credentials.
        private IFacebookClient _facebookClient;
        public AccountService(SignInManager<GaragoUser> signInManager, UserManager<GaragoUser> userManager, IConfiguration configuration, IUsersRepo userRepo, IFacebookClient facebookClient)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _userRepo = userRepo;
            _facebookClient = facebookClient;
        }


        //Pass your login form that will pass from the frontend 
        public async Task<LoginReturnVM> AttemptLogin(LoginFormVM loginForm)
        {
            //Use the signInManager 
            var result = await _signInManager.PasswordSignInAsync(loginForm.DisplayName, loginForm.Password, false, false);
 
            //If the result succeeded or if the login succeeded then login the user.
            if(result.Succeeded)
            {
                //Get the user using the userRepo
                GaragoUser userInfo = await _userRepo.GetUserInfo(loginForm.DisplayName);

                //Then create a viewmodel using the GaragoUser
                UserVM userInfoToAssign = UserModelFactory.CreateViewModel(userInfo);

                //Generate a token using your userInfoAssign variable
                var token = GenerateJwtToken(userInfoToAssign);

                //Define the infoToReturn back to the user.
                LoginReturnVM infoToReturn = AccountModelFactory.CreateViewModel(
                                                                    token,
                                                                    _configuration["TokenAuthInfo:ExpirationInMinutes"],
                                                                    userInfoToAssign
                                                                );

                //Now return the info.
                return infoToReturn;
               
            } else
            {
                throw new InvalidOperationException();
            }
        }

        //Pass your facebook credentials for user's that want to login via facebook.
        public async Task<LoginReturnVM> FacebookLogin(FacebookCredentialsVM fbCreds)
        {
            var responseData = await _facebookClient.GetAsync(fbCreds.AccessToken, "/me", "fields=id,name,birthday,email");
            Console.WriteLine(responseData);
            return new LoginReturnVM();
        }

        //Pass you register form that will passed from your frontend in order to create a user.
        public async Task<LoginReturnVM> Register(RegisterationFormVM registerForm)
        {
            //Assign your roles to your regular user registration.
            registerForm.Roles = new string[] { Roles.NormalUser, Roles.Buyer };

            //Assign your policies to your regular user registration
            registerForm.Policies = new string[] { Policies.NormalUser, Policies.BuyerOnly, Policies.Buyer };
            
            //Hash your password, and define an instance of your hasher that will be responsible for hashing your password.
            var hasher = new PasswordHasher<string>();

            //Convert your registration form to a GaragoUser so you can add it to the database.
            GaragoUser userToAdd = AccountModelFactory.CreateDomainModel(registerForm);

            //Set's its' password hash to the hashed password.
            userToAdd.PasswordHash = hasher.HashPassword(registerForm.UserName, registerForm.Password);

            //Update securityStamp
            await _userManager.UpdateSecurityStampAsync(userToAdd);

            //set your user role to a normal user and buyer.
            //userToAdd.PushNotificationToken = GenerateJwtToken()
            //The result of adding the user will return a user to convert.
            GaragoUser userToConvert = await _userRepo.AddUser(userToAdd);

            //Assign user to specified role.
            await _userManager.AddToRolesAsync(userToConvert, registerForm.Roles);

            //Define your info that will passed to your identity.
            UserVM userInfo = UserModelFactory.CreateViewModel(userToConvert);

            //Define your result 
            LoginReturnVM result = AccountModelFactory.CreateViewModel(
                                                            GenerateJwtToken(userInfo),
                                                            _configuration["TokenAuthInfo:ExpirationInMinutes"],
                                                            userInfo
                                                        );
            return result;
            
        }

        //Logout the user.
        public async Task Logout()
        {
            //Sign the out the user using the sign in manager.
            await _signInManager.SignOutAsync();
            return;
        }

        //Define a method that generates a jwt token. It takes a user view model as an argument.
        public object GenerateJwtToken(UserVM user)
        {

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.DisplayName),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Name)
            };

            //Get your secret key from your Configuration instance which is your appsettings.json
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenAuthentication:Secret"]));

            //Define your credentials, which will take your security key and a hashing algorithm.
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Define how much time until your jwt token expires, by adding to the total # of hours.
            DateTime expires = DateTime.Now.AddHours(Convert.ToDouble(_configuration["TokenAuthInfo:ExpirationInHours"]));

            //Define your token which take a issue, claims, signing credentials, and the time to expire.
            JwtSecurityToken token = new JwtSecurityToken(
                                                            issuer: _configuration["TokenAuthInfo:TokenIssuer"],
                                                            audience: _configuration["TokenAuthInfo:TokenIssuer"],
                                                            claims: claims,
                                                            expires: expires,
                                                            signingCredentials: creds
                                                          );
            //Return your generated token.
            return token;
        }
    }
}
