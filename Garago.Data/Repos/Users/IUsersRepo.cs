using Garago.Data.UtilClasses;
using Garago.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Data.Repos
{
    public interface IUsersRepo
    {

        Task<IEnumerable<GaragoUser>> GetAllUsers();

        Task<IEnumerable<GaragoUser>> FilterUsers(List<Filter> filters);

        Task<GaragoUser> GetUser(Guid userId);

        Task<GaragoUser> GetUserInfo(string displayName);

        GaragoUser GetUserNotAsync(Guid userId);

        Task<GaragoUser> AddUser(GaragoUser userToAdd);

    }
}
