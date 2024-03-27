using Thunders.Todo.Core.Repositories;
using Thunders.Todo.Domain.Entities;

namespace Thunders.Todo.Infra.Repositories
{
    public class MemoryTodoRepository : ITodoRepository
    {
        IList<TodoItemEntity> _todos = new List<TodoItemEntity>();

        public async Task CreateAsync(TodoItemEntity entity)
        {
            _todos.Add(entity);
        }

        public async Task DeleteAsync(TodoItemEntity entity)
        {
            for (int i = 0; i < _todos.Count; i++)
                if (_todos[i].Id == entity.Id)
                    _todos.RemoveAt(i);
        }

        public async Task<TodoItemEntity> GetAsync(long id)
        {
            return _todos.First(m => m.Id == id);
        }

        public async Task<IEnumerable<TodoItemEntity>> ListAsync()
        {
            return _todos;
        }

        public async Task UpdateAsync(TodoItemEntity entity)
        {
            for (int i = 0; i < _todos.Count; i++)
                if (_todos[i].Id == entity.Id)
                    _todos[i] = entity;
        }
    }
}
