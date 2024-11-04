using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TodoList.API.Controllers;

public class CustomBaseController : ControllerBase
{
    [NonAction]
    [Authorize]
    public string GetUserId()
    {
        var claims = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type.Equals(ClaimTypes.NameIdentifier));
        return claims?.Value ?? "";
    }
}
