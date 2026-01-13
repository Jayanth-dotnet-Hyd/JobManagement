using JobManagement.Applicant.Data.Models;
using JobManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRoles();
            return Ok(roles);
        }
        [HttpGet("GetRoleByCode/{code}")]
        public async Task<IActionResult> GetRoleByCode(int code)
        {
            var role = await _roleService.GetRoleByCode(code);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] role role)
        {
            await _roleService.AddRole(role);
            return Ok(new
            {
                success = true,
                message = "Role added successfully"
            });
        }
    }
}
