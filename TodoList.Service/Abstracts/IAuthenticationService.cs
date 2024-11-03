using Core.Responses;
using TodoList.Models.Dtos.Tokens.Responses;
using TodoList.Models.Dtos.Users.Requests;

namespace TodoList.Service.Abstracts;

public interface IAuthenticationService
{
    Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginUserRequest request);
    Task<ReturnModel<TokenResponseDto>> RegisterAsync(CreateUserRequest request);
}
