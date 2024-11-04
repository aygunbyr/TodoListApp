using Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models.Dtos.Categories.Requests;
using TodoList.Models.Dtos.Categories.Responses;
using TodoList.Service.Abstracts;

namespace TodoList.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ReturnModel<List<GetCategoryResponse>> result = await categoryService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        ReturnModel<GetCategoryResponse?> result = await categoryService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        ReturnModel<CreateCategoryResponse> result = await categoryService.AddAsync(request);
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryRequest request)
    {
        ReturnModel<UpdateCategoryResponse> result = await categoryService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        ReturnModel<GetCategoryResponse?> result = await categoryService.RemoveAsync(id);
        return Ok(result);
    }
}
