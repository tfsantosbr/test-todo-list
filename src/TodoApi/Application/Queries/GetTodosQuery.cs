using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApi.Application.Models;
using TodoApi.Infrastructure;

namespace TodoApi.Application.Queries;

public record GetTodosQuery : IRequest<List<TodoItemModel>>;

public class GetTodosQueryHandler(TodoDbContext context) : IRequestHandler<GetTodosQuery, List<TodoItemModel>>
{
    public async Task<List<TodoItemModel>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return await context.TodoItems
            .Select(t => new TodoItemModel(t.Id, t.Title, t.IsCompleted))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}