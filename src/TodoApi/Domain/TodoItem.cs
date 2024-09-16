namespace TodoApi.Domain;

public class TodoItem
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public bool IsCompleted { get; private set; }

    private TodoItem() { }

    public TodoItem(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("O título não pode ser vazio.");

        Id = Guid.NewGuid();
        Title = title;
        IsCompleted = false;
    }

    public void UpdateTitle(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("O título não pode ser vazio.");

        Title = newTitle;
    }

    public void MarkAsCompleted() => IsCompleted = true;

    public void MarkAsNotCompleted() => IsCompleted = false;
}
