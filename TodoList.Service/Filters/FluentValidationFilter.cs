using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Responses;

namespace TodoList.Service.Filters
{
    public class FluentValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                var resultModel = new ReturnModel<object>
                {
                    Data = null,
                    Errors = errors,
                    Message = string.Empty,
                    StatusCode = 400,
                    Success = false
                };

                context.Result = new BadRequestObjectResult(resultModel);

                return;
            }

            await next();
        }
    }
}
