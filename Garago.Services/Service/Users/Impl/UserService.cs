using Garago.Data.Repos;
using Garago.Domain;
using Garago.Services.ViewModels.User;
using Garago.Services.Factory.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Garago.Services.ViewModels.Utils;
using Garago.Data.UtilClasses;
using Garago.Services.Factory.Utils;

namespace Garago.Services.Service.Users.Impl
{
    public class UserService : IUserService
    {
        private IUsersRepo _userRepo;

        public UserService(IUsersRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<IEnumerable<UserItemVM>> GetUsers()
        {
            IEnumerable<GaragoUser> usersToConvert = await _userRepo.GetAllUsers();
            IEnumerable<UserItemVM> usersToReturn = usersToConvert.Select(user => UserModelFactory.CreateItemViewModel(user));
            return usersToReturn;
        }

        public async Task<UserVM> GetUser(Guid userId)
        {
            GaragoUser userToConvert = await _userRepo.GetUser(userId);
            UserVM userToReturn = UserModelFactory.CreateViewModel(userToConvert);
            return userToReturn;
        }

        public async Task<IEnumerable<UserItemVM>> FilterUsers(FilterVM[] filters)
        {
            List<Filter> filtersToUse = new List<Filter>();
            await Task.Run(() =>
            {
                foreach(FilterVM filter in filters)
                {
                    filtersToUse.Add(UtilsModelFactory.CreateDomainModel(filter));
                }
            });

            //FIlter the users using the filters the use variable
            var usersToConvert = await _userRepo.FilterUsers(filtersToUse);
            //Convert your userToCOnvert to an array of UserITemVM
            IEnumerable<UserItemVM> usersToReturn = usersToConvert.Select(user => UserModelFactory.CreateItemViewModel(user));
            //Return the converted users.
            return usersToReturn;
        }

    }
}
