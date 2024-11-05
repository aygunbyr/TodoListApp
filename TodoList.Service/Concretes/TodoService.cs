using AutoMapper;
using Core.Responses;
using TodoList.DataAccess.Abstracts;
using TodoList.Models.Dtos.Todos.Requests;
using TodoList.Models.Dtos.Todos.Responses;
using TodoList.Models.Entities;
using TodoList.Service.Abstracts;
using TodoList.Service.Rules;

namespace TodoList.Service.Concretes;

public class TodoService(ITodoRepository todoRepository, IMapper mapper, TodoBusinessRules businessRules) : ITodoService
{
    public async Task<ReturnModel<CreateTodoResponse>> AddAsync(CreateTodoRequest request, string userId)
    {
        Todo createdTodo = mapper.Map<Todo>(request);
        createdTodo.Id = Guid.NewGuid();
        createdTodo.UserId = userId;

        await todoRepository.AddAsync(createdTodo);

        CreateTodoResponse response = mapper.Map<CreateTodoResponse>(createdTodo);

        return new ReturnModel<CreateTodoResponse>
        {
            Data = response,
            Message = "Yapılacak iş eklendi.",
            StatusCode = 201,
            Success = true
        };
    }

    public async Task<ReturnModel<List<GetTodoResponse>>> GetAllAsync()
    {
        List<Todo> todos = await todoRepository.GetAllAsync();
        List<GetTodoResponse> response = mapper.Map<List<GetTodoResponse>>(todos);

        return new ReturnModel<List<GetTodoResponse>>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<List<GetTodoResponse>>> GetTodosByUserIdAsync(string userId)
    {
        List<Todo> todos = await todoRepository.WhereAsync(todo => todo.UserId.Equals(userId));
        List<GetTodoResponse> response = mapper.Map<List<GetTodoResponse>>(todos);

        return new ReturnModel<List<GetTodoResponse>>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<List<GetTodoResponse>>> GetTodosByFilterText(string filterText)
    {
        string filterTextLowerCase = filterText.ToLower();
        List<Todo> todos = await todoRepository.WhereAsync(todo => 
                todo.Title.ToLower().Contains(filterTextLowerCase) || 
                todo.Description.ToLower().Contains(filterTextLowerCase));
        List<GetTodoResponse> response = mapper.Map<List<GetTodoResponse>>(todos);

        return new ReturnModel<List<GetTodoResponse>>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<List<GetTodoResponse>>> GetUsersTodosByFilterText(string filterText, string userId)
    {
        string filterTextLowerCase = filterText.ToLower();
        List<Todo> todos = await todoRepository.WhereAsync(todo =>
                (todo.Title.ToLower().Contains(filterTextLowerCase) ||
                todo.Description.ToLower().Contains(filterTextLowerCase)
                && todo.UserId == userId));
        List<GetTodoResponse> response = mapper.Map<List<GetTodoResponse>>(todos);

        return new ReturnModel<List<GetTodoResponse>>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<List<GetTodoResponse>>> GetTodosByCategoryIdAsync(int categoryId)
    {
        List<Todo> todos = await todoRepository.WhereAsync(todo => todo.CategoryId.Equals(categoryId));
        List<GetTodoResponse> response = mapper.Map<List<GetTodoResponse>>(todos);

        return new ReturnModel<List<GetTodoResponse>>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<GetTodoResponse?>> GetByIdAsync(Guid id)
    {
        Todo? todo = await todoRepository.GetByIdAsync(id);
        businessRules.TodoIsNullCheck(todo);

        GetTodoResponse response = mapper.Map<GetTodoResponse>(todo);

        return new ReturnModel<GetTodoResponse?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<GetTodoResponse>> RemoveAsync(Guid id)
    {
        Todo? todo = await todoRepository.GetByIdAsync(id);
        businessRules.TodoIsNullCheck(todo);

        Todo deletedTodo = await todoRepository.RemoveAsync(todo);
        GetTodoResponse response = mapper.Map<GetTodoResponse>(deletedTodo);

        return new ReturnModel<GetTodoResponse>
        {
            Data = response,
            Message = "Yapılacak iş silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public async Task<ReturnModel<UpdateTodoResponse>> UpdateAsync(UpdateTodoRequest request)
    {
        Todo? todo = await todoRepository.GetByIdAsync(request.Id);
        businessRules.TodoIsNullCheck(todo);

        Todo newTodo = new Todo
        {
            Id = request.Id,
            Title = request.Title,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Priority = (Priority) request.Priority,
            CategoryId = request.CategoryId,
            Completed = request.Completed,
        };

        Todo updatedTodo = await todoRepository.UpdateAsync(newTodo);

        UpdateTodoResponse response = mapper.Map<UpdateTodoResponse>(updatedTodo);
        return new ReturnModel<UpdateTodoResponse>
        {
            Data = response,
            Message = "Yapılacak iş güncellendi.",
            StatusCode = 200,
            Success = true
        };
    }


}
