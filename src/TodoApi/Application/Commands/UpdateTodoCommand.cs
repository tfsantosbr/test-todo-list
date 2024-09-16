using FluentValidation.Results;
using MediatR;

namespace TodoApi.Application.Commands;

public record UpdateTodoCommand(Guid Id, string NewTitle) : IRequest<List<ValidationFailure>?>;
