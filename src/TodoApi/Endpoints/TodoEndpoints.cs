using MediatR;
using TodoApi.Application.Commands;
using TodoApi.Application.Queries;
using TodoApi.Endpoints.Models;

namespace TodoApi.Endpoints;

public static class TodoEndpoints
{
    public static void MapTodoEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/todos", async (IMediator mediator) =>
        {
            var todos = await mediator.Send(new GetTodosQuery());
            return Results.Ok(todos);
        });

        app.MapPost("/v1/todos", async (CreateTodoCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);

            if (result.Item2 != null)
                return Results.BadRequest(result.Item2);

            return Results.Ok(result.Item1);
        });

        app.MapPut("/v1/todos/{id:guid}", async (Guid id, UpdateTodoRequest request, IMediator mediator) =>
        {
            var result = await mediator.Send(new UpdateTodoCommand(id, request.Title));

            if (result != null)
                return Results.BadRequest(result);

            return Results.NoContent();
        });

        app.MapDelete("/v1/todos/{id:guid}", async (Guid id, IMediator mediator) =>
        {
            await mediator.Send(new DeleteTodoCommand(id));
            return Results.NoContent();
        });
    }
}
