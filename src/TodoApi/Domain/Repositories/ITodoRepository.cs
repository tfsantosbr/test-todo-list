namespace TodoApi.Domain.Repositories;

public interface ITodoRepository
{
    Task<TodoItem?> GetByIdAsync(Guid id);
    Task AddAsync(TodoItem todoItem);
    Task UpdateAsync(TodoItem todoItem);
    Task DeleteAsync(TodoItem todoItem);
}
