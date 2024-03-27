using System.Text;
using Thunders.Todo.Core.Repositories;
using Thunders.Todo.Core.UseCases.Dtos;
using Thunders.Todo.Domain.Entities;

namespace Thunders.Todo.Core.UseCases
{
    public class CreateTodoUseCase
    {
        private readonly ITodoRepository _repository;

        public CreateTodoUseCase(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
        }

        public async Task ExecuteAsync(CreateTodoItemInput dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Text))
                throw new ArgumentException("texto não atribuido", "text");

            DateTime? deadline = null;
            if (!string.IsNullOrWhiteSpace(dto.DeadlineDateISOFormat))
            {
                if (!DateTime.TryParse(dto.DeadlineDateISOFormat, null, System.Globalization.DateTimeStyles.None, out DateTime deadlineToParse))
                    throw new ArgumentException("não foi possivel converter a data final", "deadline");

                deadline = deadlineToParse;
            }

            var todo = new TodoItemEntity
            {
                Id = dto.Id,
                CreatedAt = DateTime.Now,
                Text = dto.Text,
                Deadline = deadline,
                IsDone = false,
            };

            await _repository.CreateAsync(todo);
        }
    }
}