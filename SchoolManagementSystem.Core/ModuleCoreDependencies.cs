using Mapster;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Core.Mapping;
using System.Reflection;

namespace SchoolManagementSystem.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddModuleCoreDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            //Mapster
            services.AddMapster();
            StudentMapping.RegisterStudentMapping();
            return services;
        }
    }
}
