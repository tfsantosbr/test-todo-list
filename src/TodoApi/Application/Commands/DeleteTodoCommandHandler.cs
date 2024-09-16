using FluentValidation.Results;
using MediatR;
using TodoApi.Domain.Repositories;

namespace TodoApi.Application.Commands;

public class DeleteTodoCommandHandler(ITodoRepository todoRepository)
    : IRequestHandler<DeleteTodoCommand, List<ValidationFailure>?>
{
    private readonly ITodoRepository _todoRepository = todoRepository;

    public async Task<List<ValidationFailure>?> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todoItem = await _todoRepository.GetByIdAsync(request.Id);

        if (todoItem is null)
            return [new("Tarefa", "Tarefa não encontrada.")];

        await _todoRepository.DeleteAsync(todoItem);

        return null;
    }
}
