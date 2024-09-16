namespace TodoApi.Application.Models;

public record TodoItemModel(Guid Id, string Title, bool IsCompleted);
