using FluentValidation.Results;
using MediatR;

namespace TodoApi.Application.Commands;

public record CreateTodoCommand(string Title) : IRequest<(Guid?, List<ValidationFailure>?)>;
