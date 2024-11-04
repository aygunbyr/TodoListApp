using Core.Exceptions;
using Core.Responses;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace BlogSite.API.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var responseModel = new ReturnModel<List<string>>
            {
                Data = null,
                Message = exception.Message,
                StatusCode = exception switch
                {
                    BadRequestException _ => StatusCodes.Status400BadRequest,
                    UnauthorizedException _ => StatusCodes.Status401Unauthorized,
                    ForbiddenException _ => StatusCodes.Status403Forbidden,
                    NotFoundException _ => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                },
                Success = false,
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = responseModel.StatusCode;

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(responseModel));
            return true;
        }
    }
}
