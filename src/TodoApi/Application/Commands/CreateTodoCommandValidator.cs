using FluentValidation;

namespace TodoApi.Application.Commands;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty().MaximumLength(200);
    }
}
