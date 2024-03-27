namespace Thunders.Todo.Core.UseCases.Dtos
{
    public record CreateTodoItemInput(long Id, string Text, string? DeadlineDateISOFormat);
}