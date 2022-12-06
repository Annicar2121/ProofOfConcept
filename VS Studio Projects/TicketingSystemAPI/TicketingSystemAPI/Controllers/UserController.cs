
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TicketingSystemAPI.Models;
using TicketingSystemAPI.Entities;
using TicketingSystemAPI.Authorization;
using TicketingSystemAPI.Services;


namespace TicketingSystemAPI.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IConfiguration _configuration;
        private IUserService _userService;

        public UserController( IConfiguration configuration,
            IUserService userService)
        {
            _userService = userService;
			_configuration = configuration;
            
        }


        //This is used for logging in users
        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Authenticate(Models.AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        //To see a current user
        [HttpGet("See_Current_User")]
        public IActionResult See_Current_User()
        {
            var currentUser = (User)HttpContext.Items["User"];
            return Ok(currentUser);
        }


        //Used for registering new users, will only be regular users
        [AllowAnonymous]
        [HttpPost("Register_User")]
        public IActionResult Register(RegisterModel model)
        {
            _userService.Register(model);
            return Ok(new { message = "Registration successful" });
        }

        //Only Admins can get all users registered in the system
        [Authorize(Role.Admin)]
        [HttpGet("Get_All_Users")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        //Delete a user from system, only Admins can do this
        [Authorize(Role.Admin)]
        [HttpDelete("Delete_User")]
        public IActionResult Delete_User(int id)
        {
            _userService.Delete_User(id);
            return Ok(new { message = "User deleted successfully" });
        }

        //get user record of specific id
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // only admins can access other user records
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != Role.Admin)
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
            else
            {
                var user = _userService.GetById(id);
                return Ok(user);
            }
        }

        [Authorize(Role.Admin)]
        //get user records of specific role
        [HttpGet("Get_Users_By_Role")]
        public IActionResult Get_Users_By_Role(Role role)
        {
             var users = _userService.Get_Users_By_Role(role);
             return Ok(users);
       
        }

        //Addming a user with the admin role
        [Authorize(Role.Admin)]
        [HttpPost("Register_Admin")]
        public IActionResult Register_Admin(RegisterModel model)
        {
            _userService.Register_Admin(model);
            return Ok(new { message = "Registration successful" });

        }

        //Adding a user witht the tech role
        [Authorize(Role.Admin, Role.Tech)]
        [HttpPost("Register_Tech")]
        public IActionResult Register_Tech(RegisterModel model)
        {
            _userService.Register_Tech(model);
            return Ok(new { message = "Registration successful" });

        }

        //change password for user of specified ID
        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword(UpdateRequest req)
        {
            // only admins can access other user records unhindered
            //users can access their own records
            var currentUser = (User)HttpContext.Items["User"];
            if (req.User.Id != currentUser.Id && currentUser.Role != Role.Admin)
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
            else
            {
                _userService.ChangePassword(req);
                return Ok(new { message = "Password Changed" });
            }
        }


    }
}
