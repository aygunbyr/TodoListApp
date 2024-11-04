using Core.Responses;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Dtos.Tokens.Responses;
using TodoList.Models.Dtos.Users.Requests;
using TodoList.Service.Abstracts;

namespace TodoList.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        ReturnModel<TokenResponseDto> result = await authenticationService.LoginAsync(request);
        return Ok(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
    {
        ReturnModel<TokenResponseDto> result = await authenticationService.RegisterAsync(request);
        return Ok(result);
    }
}
