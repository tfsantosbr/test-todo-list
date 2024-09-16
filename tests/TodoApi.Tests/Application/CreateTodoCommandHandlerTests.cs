using Moq;
using TodoApi.Application.Commands;
using TodoApi.Domain;
using TodoApi.Domain.Repositories;

namespace TodoApi.Tests.Application;

public class CreateTodoCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCreateTodoItem()
    {
        // Arrange
        var mockRepo = new Mock<ITodoRepository>();
        var command = new CreateTodoCommand("New Task");
        var handler = new CreateTodoCommandHandler(mockRepo.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepo.Verify(repo => repo.AddAsync(It.IsAny<TodoItem>()), Times.Once);
        Assert.NotEqual(Guid.Empty, result.Item1);
        Assert.Null(result.Item2);
    }
}
