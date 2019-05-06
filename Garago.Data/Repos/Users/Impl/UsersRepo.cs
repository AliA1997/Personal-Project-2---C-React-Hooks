using Garago.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Garago.Data.UtilClasses;
using Garago.Repo.Utils;

namespace Garago.Data.Repos.Users.Impl
{
    public class UsersRepo: IUsersRepo
    {
        private GaragoContext _context;
        public UsersRepo(GaragoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GaragoUser>> GetAllUsers()
        {
            IEnumerable<GaragoUser> usersToReturn = await _context.GaragoUsers.Select(user => user).ToListAsync();
            return usersToReturn;
        }

        public async Task<GaragoUser> GetUser(Guid userId)
        {
            GaragoUser userToReturn = await _context.GaragoUsers.FirstOrDefaultAsync(user => Guid.Parse(user.Id) == userId);
            return userToReturn; 
        }

        public async Task<GaragoUser> GetUserInfo(string displayName)
        {
            GaragoUser userInfoToReturn = await _context.GaragoUsers.FirstOrDefaultAsync(user => user.Email == displayName || user.UserName == displayName);
            return userInfoToReturn;
        }

        public GaragoUser GetUserNotAsync(Guid userId)
        {
            GaragoUser userToReturn = _context.GaragoUsers.FirstOrDefault(user => user != null);
            if (userToReturn == null)
                return _context.Users.Single();
            else 
                return userToReturn;
        }

        public async Task<IEnumerable<GaragoUser>> FilterUsers(List<Filter> filters)
        {
            List<GaragoUser> usersToReturn = new List<GaragoUser>();
            await Task.Run(() =>
            {
                foreach (Filter filter in filters)
                {
                    var temp = _context.GaragoUsers.Where(user => FilterUtils.CheckUserFilter(user, filter)).Take(250);
                    usersToReturn.AddRange(temp);
                }
            });
            usersToReturn = usersToReturn.Distinct().ToList();
            return usersToReturn;
        }

        public async Task<GaragoUser> AddUser(GaragoUser userToAdd)
        {
            await _context.GaragoUsers.AddAsync(userToAdd);
            await _context.SaveChangesAsync();
            return userToAdd;
        }
    }
}
