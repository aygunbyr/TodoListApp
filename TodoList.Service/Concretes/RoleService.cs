using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.Models.Entities;

public class RoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<User> _userManager;

    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<IdentityResult> ChangeUserRoleAsync(string email, string newRole)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });
        }

        var currentRoles = await _userManager.GetRolesAsync(user);
        var result = await _userManager.RemoveFromRolesAsync(user, currentRoles);

        if (result.Succeeded)
        {
            result = await _userManager.AddToRoleAsync(user, newRole);
        }

        return result;
    }

    public async Task<IdentityResult> AddRoleAsync(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            return IdentityResult.Failed(new IdentityError { Description = $"Rol zaten mevcut: {roleName}" });
        }

        var role = new IdentityRole(roleName);
        return await _roleManager.CreateAsync(role);
    }

    public async Task<IList<string>> GetUserRolesAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            return new List<string>();
        }

        return await _userManager.GetRolesAsync(user);
    }
}
