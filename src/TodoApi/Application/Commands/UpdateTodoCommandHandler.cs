using FluentValidation.Results;
using MediatR;
using TodoApi.Domain.Repositories;

namespace TodoApi.Application.Commands;

public class UpdateTodoCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<UpdateTodoCommand, List<ValidationFailure>?>
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<List<ValidationFailure>?> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var validationResult = new UpdateTodoCommandValidator().Validate(request);

        if (!validationResult.IsValid)
            return validationResult.Errors;

        var todoItem = await _todoRepository.GetByIdAsync(request.Id);

        if (todoItem is null)
            return [new("Tarefa", "Tarefa não encontrada.")];

        todoItem.UpdateTitle(request.NewTitle);

        await _todoRepository.UpdateAsync(todoItem);

        return null;
    }
}
