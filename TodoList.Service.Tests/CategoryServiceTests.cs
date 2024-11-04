using AutoMapper;
using Moq;
using TodoList.DataAccess.Abstracts;
using TodoList.Models.Dtos.Categories.Requests;
using TodoList.Models.Dtos.Categories.Responses;
using TodoList.Models.Entities;
using TodoList.Service.Concretes;
using TodoList.Service.Rules;

namespace TodoList.Service.Tests;

public class CategoryServiceTests
{
    private CategoryService _categoryService;
    private Mock<ICategoryRepository> _mockRepository;
    private Mock<IMapper> _mockMapper;
    private Mock<CategoryBusinessRules> _mockRules;

    [SetUp]
    public void SetUp()
    {
        _mockRepository = new Mock<ICategoryRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockRules = new Mock<CategoryBusinessRules>();

        _categoryService = new CategoryService(_mockRepository.Object, _mockMapper.Object, _mockRules.Object);
    }

    [Test]
    public async Task CategoryService_WhenCategoryAdded_ReturnSuccess()
    {
        // Arrange
        CreateCategoryRequest request = new CreateCategoryRequest("Kategori");

        Category category = new Category()
        {
            Id = 1,
            Name = request.Name
        };

        CreateCategoryResponse response = new CreateCategoryResponse(1, request.Name, DateTime.UtcNow);

        _mockMapper.Setup(x => x.Map<Category>(request)).Returns(category);
        _mockRepository.Setup(x => x.AddAsync(category)).Returns(Task.FromResult(category));
        _mockMapper.Setup(x => x.Map<CreateCategoryResponse>(category)).Returns(response);

        // Act
        var result = await _categoryService.AddAsync(request);

        // Assert
        Assert.IsTrue(result.Success);
        Assert.AreEqual(response, result.Data);
        Assert.AreEqual(201, result.StatusCode);
        Assert.AreEqual("Kategori eklendi.", result.Message);
    }

    [Test]
    public void GetById_WhenCategoryIsPresent_ReturnsSuccess()
    {
        int id = 1;
        Category category = new Category()
        {
            Id = id,
            Name = "Kategori"
        };

        GetCategoryResponse response = new GetCategoryResponse(1, "Kategori", DateTime.UtcNow, null, null);

        _mockRepository.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(category);
        _mockRules.Setup(x => x.CategoryIsNullCheck(category));
        _mockMapper.Setup(x => x.Map<GetCategoryResponse>(category)).Returns(response);

        var result = _categoryService.GetByIdAsync(id).Result;

        Assert.AreEqual(response, result.Data);
        Assert.IsTrue(result.Success);
    }

}
