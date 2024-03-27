using Thunders.Todo.Core.Repositories;
using Thunders.Todo.Core.UseCases.Dtos;
using Thunders.Todo.Domain.Entities;

namespace Thunders.Todo.Core.UseCases
{
    public class ListTodoUseCase
    {
        private readonly ITodoRepository _repository;

        public ListTodoUseCase(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
        }

        public async Task<IEnumerable<TodoItemEntity>> ExecuteAsync()
        {
            return await _repository.ListAsync();
        }
    }
}