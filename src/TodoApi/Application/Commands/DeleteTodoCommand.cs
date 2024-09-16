using FluentValidation.Results;
using MediatR;

namespace TodoApi.Application.Commands;

public record DeleteTodoCommand(Guid Id) : IRequest<List<ValidationFailure>?>;
