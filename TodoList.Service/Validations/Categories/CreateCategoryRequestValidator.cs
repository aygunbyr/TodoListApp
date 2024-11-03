using FluentValidation;
using TodoList.Models.Dtos.Categories.Requests;

namespace TodoList.Service.Validations.Categories;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryRequestValidator()
    {
        RuleFor(category => category.Name).NotEmpty().WithMessage("Kategori ismi boş olamaz.");
    }
}
