using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SchoolManagementSystem.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddModuleCoreDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddMapster();
            return services;
        }
    }
}
