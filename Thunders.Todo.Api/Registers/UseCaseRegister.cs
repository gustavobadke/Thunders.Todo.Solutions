using System.Reflection;

namespace Thunders.Todo.Api.Registers
{
    public static class UseCaseRegister
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            Assembly.Load("Thunders.Todo.Core")
                .GetTypes()
                .Where(a => a.Name.EndsWith("UseCase") && !a.IsAbstract && !a.IsInterface)
                .ToList().ForEach(typeToRegister =>
                {
                    services.AddSingleton(typeToRegister);
                });

            return services;
        }
    }
}