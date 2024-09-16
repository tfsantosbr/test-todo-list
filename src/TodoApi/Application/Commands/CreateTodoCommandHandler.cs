using FluentValidation.Results;
using MediatR;
using TodoApi.Domain;
using TodoApi.Domain.Repositories;

namespace TodoApi.Application.Commands;

public class CreateTodoCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<CreateTodoCommand, (Guid?, List<ValidationFailure>?)>
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<(Guid?, List<ValidationFailure>?)> Handle(
        CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = new CreateTodoCommandValidator().Validate(request);

        if (!validationResult.IsValid)
            return (null, validationResult.Errors);

        var todoItem = new TodoItem(request.Title);

        await _todoRepository.AddAsync(todoItem);

        return (todoItem.Id, null);
    }
}
