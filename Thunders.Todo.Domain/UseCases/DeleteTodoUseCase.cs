using Thunders.Todo.Core.Repositories;

namespace Thunders.Todo.Core.UseCases
{
    public class DeleteTodoUseCase
    {
        private readonly ITodoRepository _repository;

        public DeleteTodoUseCase(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
        }

        public async Task ExecuteAsync(long id)
        {
            var todo = await _repository.GetAsync(id);
            await _repository.DeleteAsync(todo);
        }
    }
}