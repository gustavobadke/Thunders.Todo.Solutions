using Moq;
using Thunders.Todo.Core.Repositories;
using Thunders.Todo.Core.UseCases;
using Thunders.Todo.Domain.Entities;

namespace Thunders.Todo.Core.Tests
{
    public class DeleteTodoUseCaseTest
    {

        [Fact]
        public async Task DeleteTodoItemWithSuccess()
        {
            Mock<ITodoRepository> repoFake = new(MockBehavior.Strict);

            var fake = new TodoItemEntity
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Text = "Test",
                IsDone = true,
                Deadline = DateTime.Now
            };

            repoFake
                .Setup(s => s.DeleteAsync(It.IsAny<TodoItemEntity>()))
                .Returns(Task.CompletedTask);

            repoFake
                .Setup(s => s.GetAsync(1))
                .Returns(Task.FromResult(fake));

            var useCase = new DeleteTodoUseCase(repoFake.Object);

            await useCase.ExecuteAsync(1);

            repoFake.Verify();
        }

        [Fact]
        public async Task DeleteTodoItemWithWrongId()
        {
            Mock<ITodoRepository> repoFake = new(MockBehavior.Strict);

            repoFake
                .Setup(s => s.GetAsync(1))
                .Returns<TodoItemEntity>(null);

            var useCase = new DeleteTodoUseCase(repoFake.Object);

            await Assert.ThrowsAsync<NullReferenceException>(() => useCase.ExecuteAsync(1));
        }
    }
}