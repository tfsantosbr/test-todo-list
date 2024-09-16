using TodoApi.Domain;

namespace TodoApi.Tests.Domain;

public class TodoItemTests
{
    [Fact]
    public void Constructor_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        var todoItem = new TodoItem("Test Task");

        // Assert
        Assert.True(todoItem.Id != Guid.Empty);
        Assert.Equal("Test Task", todoItem.Title);
        Assert.False(todoItem.IsCompleted);
    }

    [Fact]
    public void UpdateTitle_ShouldChangeTitle_WhenValidTitleIsProvided()
    {
        // Arrange
        var todoItem = new TodoItem("Test Task");

        // Act
        todoItem.UpdateTitle("Updated Task");

        // Assert
        Assert.Equal("Updated Task", todoItem.Title);
    }

    [Fact]
    public void UpdateTitle_ShouldThrowArgumentException_WhenTitleIsEmpty()
    {
        // Arrange
        var todoItem = new TodoItem("Test Task");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => todoItem.UpdateTitle(""));
    }

    [Fact]
    public void MarkAsCompleted_ShouldSetIsCompletedToTrue()
    {
        // Arrange
        var todoItem = new TodoItem("Test Task");

        // Act
        todoItem.MarkAsCompleted();

        // Assert
        Assert.True(todoItem.IsCompleted);
    }

    [Fact]
    public void MarkAsNotCompleted_ShouldSetIsCompletedToFalse()
    {
        // Arrange
        var todoItem = new TodoItem("Test Task");
        todoItem.MarkAsCompleted();

        // Act
        todoItem.MarkAsNotCompleted();

        // Assert
        Assert.False(todoItem.IsCompleted);
    }
}
