using AutoMapper;
using Moq;
using TodoList.DataAccess.Abstracts;
using TodoList.Models.Dtos.Todos.Requests;
using TodoList.Models.Dtos.Todos.Responses;
using TodoList.Models.Entities;
using TodoList.Service.Concretes;
using TodoList.Service.Rules;

namespace TodoList.Service.Tests;

public class TodoServiceTests
{
    private TodoService _todoService;
    private Mock<ITodoRepository> _mockRepository;
    private Mock<IMapper> _mockMapper;
    private Mock<TodoBusinessRules> _mockRules;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<ITodoRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockRules = new Mock<TodoBusinessRules>();

        _todoService = new TodoService(_mockRepository.Object, _mockMapper.Object, _mockRules.Object);
    }

    [Test]
    public async Task TodoService_WhenTodoAdded_ReturnSuccess()
    {
        // Arrange
        CreateTodoRequest request = new CreateTodoRequest("Title", "Description", DateTime.UtcNow, DateTime.UtcNow, 1, 1, false);

        Guid id = Guid.NewGuid();
        Todo todo = new Todo()
        {
            Id = id,
            Title = "Title",
            Description = "Description",
            CreatedDate = DateTime.UtcNow,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow,
            CategoryId = 1,
            Priority = (Priority)1,
            Completed = false,
            UserId = "someUserId",
        };

        CreateTodoResponse response = new CreateTodoResponse(
            Id: Guid.NewGuid(),
            Title: request.Title,
            Description: request.Description,
            CreatedDate: DateTime.UtcNow,
            StartDate: request.StartDate,
            EndDate: request.EndDate,
            Priority: request.Priority,
            CategoryId: request.CategoryId,
            Completed: request.Completed,
            UserId: "someUserId"
            );

        _mockMapper.Setup(x => x.Map<Todo>(request)).Returns(todo);
        _mockRepository.Setup(x => x.AddAsync(todo)).Returns(Task.FromResult(todo));
        _mockMapper.Setup(x => x.Map<CreateTodoResponse>(todo)).Returns(response);

        // Act
        var result = await _todoService.AddAsync(request, "someUserId");

        // Assert
        Assert.IsTrue(result.Success);
        Assert.AreEqual(response, result.Data);
        Assert.AreEqual(201, result.StatusCode);
        Assert.AreEqual("Yapılacak iş eklendi.", result.Message);
    }

    [Test]
    public void GetById_WhenTodoIsPresent_ReturnsSuccess()
    {
        Guid id = Guid.NewGuid();
        Todo todo = new Todo()
        {
            Id = id,
            Title = "Title",
            Description = "Description",
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            StartDate = DateTime.UtcNow,
            EndDate = DateTime.UtcNow,
            CategoryId = 1,
            Priority = (Priority)1,
            Completed = false,
            UserId = "someUserId",
        };

        GetTodoResponse response = new GetTodoResponse(
            Id: Guid.NewGuid(),
            Title: todo.Title,
            Description: todo.Description,
            StartDate: todo.StartDate,
            EndDate: todo.EndDate,
            CreatedDate: todo.CreatedDate,
            UpdatedDate: todo.UpdatedDate,
            Priority: (int) todo.Priority,
            CategoryId: todo.CategoryId,
            Completed: todo.Completed,
            Category: null,
            UserId: todo.UserId,
            User: null
            );

        _mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(todo);
        _mockRules.Setup(x => x.TodoIsNullCheck(todo));
        _mockMapper.Setup(x => x.Map<GetTodoResponse>(todo)).Returns(response);

        var result = _todoService.GetByIdAsync(id).Result;

        Assert.AreEqual(response, result.Data);
        Assert.IsTrue(result.Success);
    }

}
