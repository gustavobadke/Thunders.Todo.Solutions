using Moq;
using Thunders.Todo.Core.Repositories;
using Thunders.Todo.Core.UseCases;
using Thunders.Todo.Core.UseCases.Dtos;
using Thunders.Todo.Domain.Entities;

namespace Thunders.Todo.Core.Tests
{
    public class CreateTodoUseCaseTest
    {
        [Fact]
        public async Task CreateTodoItemWithSuccess()
        {
            Mock<ITodoRepository> repoFake = new(MockBehavior.Strict);

            repoFake
                .Setup(s => s.CreateAsync(It.IsAny<TodoItemEntity>()))
                .Returns(Task.CompletedTask);

            var useCase = new CreateTodoUseCase(repoFake.Object);

            var mock = new CreateTodoItemInput(1, "Item 1", "2024-03-26T21:13:04.822Z");   

            await useCase.ExecuteAsync(mock);

            repoFake.Verify();
        }

        [Fact]
        public async Task CreateTodoItemWithWrongDate()
        {
            Mock<ITodoRepository> repoFake = new(MockBehavior.Strict);

            repoFake
                .Setup(s => s.CreateAsync(It.IsAny<TodoItemEntity>()))
                .Returns(Task.CompletedTask);

            var useCase = new CreateTodoUseCase(repoFake.Object);

            var mock = new CreateTodoItemInput(1, "Item 1", "2024-0-2621:13:04.822Z");

            await Assert.ThrowsAsync<ArgumentException>("deadline", () => useCase.ExecuteAsync(mock));
        }

        [Fact]
        public async Task CreateTodoItemWithoutText()
        {
            Mock<ITodoRepository> repoFake = new(MockBehavior.Strict);

            repoFake
                .Setup(s => s.CreateAsync(It.IsAny<TodoItemEntity>()))
                .Returns(Task.CompletedTask);

            var useCase = new CreateTodoUseCase(repoFake.Object);

            var mock = new CreateTodoItemInput(1, "", "2024-0-2621:13:04.822Z");

            await Assert.ThrowsAsync<ArgumentException>("text", () => useCase.ExecuteAsync(mock));
        }
    }
}