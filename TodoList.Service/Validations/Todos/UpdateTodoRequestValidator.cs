using FluentValidation;
using TodoList.Models.Dtos.Todos.Requests;

namespace TodoList.Service.Validations.Todos;

public class UpdateTodoRequestValidator : AbstractValidator<UpdateTodoRequest>
{
    public UpdateTodoRequestValidator()
    {
        RuleFor(todo => todo.Id).NotEmpty().WithMessage("Yapılacak işin ID bilgisi gereklidir.");
        RuleFor(todo => todo.Title).NotEmpty().WithMessage("Yapılacak işin başlığı boş olamaz.");
        RuleFor(todo => todo.Description).NotEmpty().WithMessage("Yapılacak işin tanımı boş olamaz.");
        RuleFor(todo => todo.StartDate).NotEmpty().WithMessage("Yapılacak işin başlangıç tarihi gereklidir.");
        RuleFor(todo => todo.EndDate).NotEmpty().WithMessage("Yapılacak işin bitiş tarihi gereklidir.");
        RuleFor(todo => todo.Priority).NotEmpty().WithMessage("Yapılacak işin öncelik düzeyi gereklidir.");
        RuleFor(todo => todo.CategoryId).NotEmpty().WithMessage("Yapılacak işin kategorisi gereklidir.");
        RuleFor(todo => todo.Completed).NotEmpty().WithMessage("Yapılacak işin tamamlanma durumu gereklidir.");
    }
}