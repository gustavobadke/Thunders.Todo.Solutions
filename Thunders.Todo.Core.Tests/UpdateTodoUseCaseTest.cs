using Moq;
using Thunders.Todo.Core.Repositories;
using Thunders.Todo.Core.UseCases;
using Thunders.Todo.Core.UseCases.Dtos;
using Thunders.Todo.Domain.Entities;

namespace Thunders.Todo.Core.Tests
{
    public class UpdateTodoUseCaseTest
    {
        private Mock<ITodoRepository> _repoFake;

        public UpdateTodoUseCaseTest()
        {
            _repoFake = new(MockBehavior.Strict);

            _repoFake
                .Setup(s => s.UpdateAsync(It.IsAny<TodoItemEntity>()))
                .Returns(Task.CompletedTask);

            var fake = new TodoItemEntity
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Text = "Test",
                IsDone = true,
                Deadline = DateTime.Now
            };

            _repoFake
                .Setup(s => s.GetAsync(1))
                .Returns(Task.FromResult(fake));

            _repoFake
                .Setup(s => s.GetAsync(2))
                .Returns<TodoItemEntity>(null);
        }

        [Fact]
        public async Task UpdateTodoItemWithSuccess()
        {
            var useCase = new UpdateTodoUseCase(_repoFake.Object);

            var mock = new UpdateTodoItemInput(1, "Item 1", "2024-03-26T21:13:04.822Z", true);

            await useCase.ExecuteAsync(mock);

            _repoFake.Verify();
        }

        [Fact]
        public async Task UpdateTodoItemWithWrongDate()
        {
            var useCase = new UpdateTodoUseCase(_repoFake.Object);

            var mock = new UpdateTodoItemInput(1, "Item 1", "2024-0-2621:13:04.822Z", true);

            await Assert.ThrowsAsync<ArgumentException>("deadline", () => useCase.ExecuteAsync(mock));
        }

        [Fact]
        public async Task UpdateTodoItemWithoutText()
        {
            var useCase = new UpdateTodoUseCase(_repoFake.Object);

            var mock = new UpdateTodoItemInput(1, "", "2024-0-2621:13:04.822Z", true);

            await Assert.ThrowsAsync<ArgumentException>("text", () => useCase.ExecuteAsync(mock));
        }

        [Fact]
        public async Task UpdateTodoItemWithWrongId()
        {
            var useCase = new UpdateTodoUseCase(_repoFake.Object);

            var mock = new UpdateTodoItemInput(2, "Item 2", "2024-03-26T21:13:04.822Z", true);

            await Assert.ThrowsAsync<NullReferenceException>(() => useCase.ExecuteAsync(mock));
        }
    }
}