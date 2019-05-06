using Garago.Services.ViewModels.User;
using Garago.Services.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Garago.Services.Service.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserItemVM>> GetUsers();

        Task<IEnumerable<UserItemVM>> FilterUsers(FilterVM[] filters);

        Task<UserVM> GetUser(Guid userId);

    }
}
