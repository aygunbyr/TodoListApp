using FluentValidation;
using TodoList.Models.Dtos.Categories.Requests;

namespace TodoList.Service.Validations.Categories;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
    {
        RuleFor(category => category.Id).NotEmpty().WithMessage("Kategori Id gereklidir.");
        RuleFor(category => category.Name).NotEmpty().WithMessage("Kategori ismi boş olamaz.");
    }
}