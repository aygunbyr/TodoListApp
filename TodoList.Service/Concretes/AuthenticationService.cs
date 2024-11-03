using Core.Responses;
using TodoList.Models.Dtos.Tokens.Responses;
using TodoList.Models.Dtos.Users.Requests;
using TodoList.Service.Abstracts;

namespace TodoList.Service.Concretes;

public class AuthenticationService(IUserService userService, IJwtService jwtService) : IAuthenticationService
{
    public async Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginUserRequest request)
    {
        var user = await userService.LoginAsync(request);
        var response = await jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = response,
            Message = "Giriş başarılı",
            StatusCode = 200,
            Success = true,
        };
    }

    public async Task<ReturnModel<TokenResponseDto>> RegisterAsync(CreateUserRequest request)
    {
        var user = await userService.RegisterAsync(request);
        var response = await jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = response,
            Message = "Kayıt işlemi başarılı",
            StatusCode = 200,
            Success = true
        };
    }
}
