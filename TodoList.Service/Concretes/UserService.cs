using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using TodoList.Models.Dtos.Users.Requests;
using TodoList.Models.Entities;
using TodoList.Service.Abstracts;

namespace TodoList.Service.Concretes;

public class UserService(UserManager<User> userManager) : IUserService
{
    public async Task<User> ChangePasswordAsync(string id, UpdateUserPasswordRequest request)
    {
        User? user = await userManager.FindByIdAsync(id);
        if(user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }
        if(request.NewPassword.Equals(request.NewPasswordAgain) is false)
        {
            throw new BadRequestException("Parolalar uyuşmuyor.");
        }

        var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
        CheckForIdentityResult(result);

        return user;
    }

    public async Task<string> DeleteAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);
        if(user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        var result = await userManager.DeleteAsync(user);
        CheckForIdentityResult(result);

        return "Kullanıcı silindi";
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        User? user = await userManager.FindByEmailAsync(email);
        if(user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        return user;
    }

    public async Task<User> LoginAsync(LoginUserRequest request)
    {
        User? user = await userManager.FindByEmailAsync(request.Email);

        // Kötü niyetli insanların deneyerek bir eposta adresinin veritabanında
        // kayıtlı olup olmadığını anlamalarını önlemek için her iki durumda da
        // Aynı durum kodu ve aynı hata mesajını gönderiyorum.

        if(user is null)
        {
            throw new BadRequestException("Email veya parola yanlış.");
        }

        bool passwordCorrect = await userManager.CheckPasswordAsync(user, request.Password);

        if(passwordCorrect is false)
        {
            throw new BadRequestException("Email veya parola yanlış.");
        }

        return user;
    }

    public async Task<User> RegisterAsync(CreateUserRequest request)
    {
        User user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Username,
        };
        var result = await userManager.CreateAsync(user, request.Password);
        CheckForIdentityResult(result);

        return user;
    }

    public async Task<User> UpdateAsync(string id, UpdateUserRequest request)
    {
        User? user = await userManager.FindByIdAsync(id);
        if(user is null)
        {
            throw new NotFoundException("Kullanıcı bulunamadı.");
        }

        user.UserName = request.Username;
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;

        var result = await userManager.UpdateAsync(user);
        CheckForIdentityResult(result);

        return user;
    }

    private void CheckForIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            throw new BadRequestException(result.Errors.ToList().First().Description);
        }
    }
}
