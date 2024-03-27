using Moq;
using Thunders.Todo.Core.Repositories;
using Thunders.Todo.Core.UseCases;
using Thunders.Todo.Domain.Entities;

namespace Thunders.Todo.Core.Tests
{
    public class ListTodoUseCaseTest
    {
        private Mock<ITodoRepository> _repoFake;

        public ListTodoUseCaseTest()
        {
            var stubs = (IEnumerable<TodoItemEntity>)new List<TodoItemEntity>() {
                new TodoItemEntity { Id = 1, CreatedAt = DateTime.Now, Deadline = DateTime.Now, IsDone = false, Text= "Item 1" },
                new TodoItemEntity { Id = 2, CreatedAt = DateTime.Now, Deadline = DateTime.Now, IsDone = true, Text= "Item 2" },
                new TodoItemEntity { Id = 3, CreatedAt = DateTime.Now, Deadline = DateTime.Now, IsDone = false, Text= "Item 3" },
                new TodoItemEntity { Id = 4, CreatedAt = DateTime.Now, Deadline = DateTime.Now, IsDone = false, Text= "Item 4" }
            };

            _repoFake = new(MockBehavior.Strict);

            _repoFake
                .Setup(s => s.ListAsync())
                .Returns(Task.FromResult(stubs));
        }

        [Fact]
        public async Task ListTodoItemWithSuccess()
        {
            var useCase = new ListTodoUseCase(_repoFake.Object);

            var result = await useCase.ExecuteAsync();

            _repoFake.Verify();
        }
    }
}