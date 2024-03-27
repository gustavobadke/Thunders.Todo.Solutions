using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thunders.Todo.Core.UseCases.Dtos
{
    public record UpdateTodoItemInput(long Id, string Text, string? DeadlineDateISOFormat, bool IsDone);
}
