using JobManagement.Applicant.Data.Models;
using JobManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
                return Unauthorized("UserId claim missing in token");

            long userId = long.Parse(userIdClaim.Value);

            var user = await _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmail(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] user user)
        {
            await _userService.AddUser(user);
            return Ok(new
            {
                success = true,
                message = "User added successfully"
            });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] user user)
        {
            await _userService.UpdateUser(user);
            return Ok(new
            {
                success = true,
                message = "User updated successfully"
            });
        }
    }
}

