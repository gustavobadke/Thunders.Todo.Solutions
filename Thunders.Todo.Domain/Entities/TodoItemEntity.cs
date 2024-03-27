namespace Thunders.Todo.Domain.Entities
{
    public class TodoItemEntity : EntityBase    
    {
        public string Text { get; set; }
        public DateTime? Deadline { get; set; }
        public bool IsDone { get; set; }
    }
}
