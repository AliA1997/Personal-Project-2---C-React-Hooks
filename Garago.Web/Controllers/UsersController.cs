using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garago.Services.Service.Users;
using Garago.Services.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garago.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<UserItemVM> usersToReturn = await _userService.GetUsers();
            return Ok(usersToReturn);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            UserVM userToReturn = await _userService.GetUser(userId);
            return Ok(userToReturn);
        }
    }
}