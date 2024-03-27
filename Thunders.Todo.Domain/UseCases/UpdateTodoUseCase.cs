using Thunders.Todo.Core.Repositories;
using Thunders.Todo.Core.UseCases.Dtos;

namespace Thunders.Todo.Core.UseCases
{
    public class UpdateTodoUseCase
    {
        private readonly ITodoRepository _repository;

        public UpdateTodoUseCase(ITodoRepository todoRepository)
        {
            _repository = todoRepository;
        }

        public async Task ExecuteAsync(UpdateTodoItemInput dto)
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

            var todo = await _repository.GetAsync(dto.Id);

            todo.Text = dto.Text;
            todo.Deadline = deadline;
            todo.IsDone = dto.IsDone;

            await _repository.UpdateAsync(todo);
        }
    }
}