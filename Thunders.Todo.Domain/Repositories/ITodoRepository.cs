using Thunders.Todo.Domain.Entities;

namespace Thunders.Todo.Core.Repositories
{
    public interface ITodoRepository
    {
        Task CreateAsync(TodoItemEntity entity);

        Task UpdateAsync(TodoItemEntity entity);

        Task DeleteAsync(TodoItemEntity entity);

        Task<IEnumerable<TodoItemEntity>> ListAsync();

        Task<TodoItemEntity> GetAsync(long id);
    }
}