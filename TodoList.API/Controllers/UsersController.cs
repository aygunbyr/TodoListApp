using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Entities;
using TodoList.Service.Abstracts;

namespace TodoList.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin")]
public class UsersController(IUserService userService, RoleService roleService) : ControllerBase
{
    [HttpGet("email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email)
    {
        User result = await userService.GetByEmailAsync(email);
        return Ok(result);
    }

    [HttpPost("add-role")]
    public async Task<IActionResult> AddRole(string roleName)
    {
        if (string.IsNullOrWhiteSpace(roleName))
        {
            return BadRequest("Rol adı boş olamaz.");
        }

        var result = await roleService.AddRoleAsync(roleName);
        return result.Succeeded ? Ok($"Rol başarıyla eklendi: {roleName}") : BadRequest(result.Errors);
    }

    [HttpPost("change-role")]
    public async Task<IActionResult> ChangeUserRole(string email, string newRole)
    {
        var result = await roleService.ChangeUserRoleAsync(email, newRole);
        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

    [HttpGet("get-roles")]
    public async Task<IActionResult> GetUserRoles(string email)
    {
        var roles = await roleService.GetUserRolesAsync(email);
        return Ok(roles);
    }
}
