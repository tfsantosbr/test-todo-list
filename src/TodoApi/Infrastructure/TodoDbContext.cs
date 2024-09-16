using Microsoft.EntityFrameworkCore;
using TodoApi.Domain;

namespace TodoApi.Infrastructure;

public class TodoDbContext(DbContextOptions<TodoDbContext> options)
    : DbContext(options)
{
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.ToTable("Todos").HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .IsRequired();

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.IsCompleted)
                .IsRequired();

            entity.HasIndex(e => e.Title);
        });
    }
}
