using TodoApi.Domain;
using TodoApi.Domain.Repositories;

namespace TodoApi.Infrastructure.Repositories;

public class TodoRepository(TodoDbContext context) : ITodoRepository
{
    private readonly TodoDbContext _context = context;

    public async Task<TodoItem?> GetByIdAsync(Guid id)
    {
        return await _context.TodoItems.FindAsync(id);
    }

    public async Task AddAsync(TodoItem todoItem)
    {
        await _context.TodoItems.AddAsync(todoItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TodoItem todoItem)
    {
        _context.TodoItems.Update(todoItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TodoItem todoItem)
    {
        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();
    }
}
