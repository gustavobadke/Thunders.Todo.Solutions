using System.Runtime.CompilerServices;
using Thunders.Todo.Core.Repositories;
using Thunders.Todo.Infra.Repositories;

namespace Thunders.Todo.Api.Registers
{
    public static class RepositoryRegister
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddSingleton<ITodoRepository, MemoryTodoRepository>();
            return services;
        }
    }
}
