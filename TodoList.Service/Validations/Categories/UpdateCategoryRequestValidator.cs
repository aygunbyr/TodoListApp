using FluentValidation;
using TodoList.Models.Dtos.Categories.Requests;

namespace TodoList.Service.Validations.Categories;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        RuleFor(category => category.Id).GreaterThan(0).WithMessage("Kategori Id gereklidir.");
        RuleFor(category => category.Name).NotEmpty().WithMessage("Kategori ismi boş olamaz.");
    }
}