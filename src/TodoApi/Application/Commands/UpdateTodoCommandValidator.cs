using FluentValidation;

namespace TodoApi.Application.Commands;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(c => c.NewTitle).NotEmpty().MaximumLength(200);
    }
}
