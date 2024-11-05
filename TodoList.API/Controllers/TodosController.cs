using Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Dtos.Todos.Requests;
using TodoList.Models.Dtos.Todos.Responses;
using TodoList.Service.Abstracts;

namespace TodoList.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController(ITodoService todoService) : CustomBaseController
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        ReturnModel<List<GetTodoResponse>> result = await todoService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("currentUser")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUserTodos()
    {
        string userId = GetUserId();
        ReturnModel<List<GetTodoResponse>> result = await todoService.GetTodosByUserIdAsync(userId);
        return Ok(result);
    }

    [HttpGet("currentUserFiltered/{filterText}")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUserFilteredTodos(string filterText)
    {
        string userId = GetUserId();
        ReturnModel<List<GetTodoResponse>> result = await todoService.GetUsersTodosByFilterText(filterText, userId);
        return Ok(result);
    }

    [HttpGet("filter/{filterText}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetFilteredTodos(string filterText)
    {
        ReturnModel<List<GetTodoResponse>> result = await todoService.GetTodosByFilterText(filterText);
        return Ok(result);
    }

    
    [HttpGet("user/{userId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetTodosByUser(string userId)
    {
        ReturnModel<List<GetTodoResponse>> result = await todoService.GetTodosByUserIdAsync(userId);
        return Ok(result);
    }

    [HttpGet("category/{categoryId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetTodosByCategory(int categoryId)
    {
        ReturnModel<List<GetTodoResponse>> result = await todoService.GetTodosByCategoryIdAsync(categoryId);
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateTodoRequest request)
    {
        string userId = GetUserId();
        ReturnModel<CreateTodoResponse> result = await todoService.AddAsync(request, userId);
        return Ok(result);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateTodoRequest request)
    {
        ReturnModel<UpdateTodoResponse> result = await todoService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        ReturnModel<GetTodoResponse> result = await todoService.RemoveAsync(id);
        return Ok(result);
    }
}
