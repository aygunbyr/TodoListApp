using TodoList.Models.Dtos.Users.Requests;
using TodoList.Models.Entities;

namespace TodoList.Service.Abstracts;

public interface IUserService
{
    Task<User> RegisterAsync(CreateUserRequest request);
    Task<User> GetByEmailAsync(string email);
    Task<User> LoginAsync(LoginUserRequest request);
    Task<User> UpdateAsync(string id, UpdateUserRequest request);
    Task<User> ChangePasswordAsync(string id, UpdateUserPasswordRequest request);
    Task<string> DeleteAsync(string id);
}
