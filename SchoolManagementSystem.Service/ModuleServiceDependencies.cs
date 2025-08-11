using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Service.Abstracts;
using SchoolManagementSystem.Service.Implementations;

namespace SchoolManagementSystem.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}
