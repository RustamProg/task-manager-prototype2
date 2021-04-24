using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerPrototype2.Models.Auth;
using TaskManagerPrototype2.Models.Entites;
using TaskManagerPrototype2.Services;

namespace TaskManagerPrototype2.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("auth")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            if (response == null)
            {
                return BadRequest(new {ErrorMessage = "Invalid username or password"});
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            var response = _userService.Register(user);
            if (response == null)
            {
                return BadRequest(new {ErrorMessage = "This user doesn't exist"});
            }

            return Ok(response);
        }

        [Authorize]
        [HttpGet("all-users")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}