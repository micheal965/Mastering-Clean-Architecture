using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Core.Behaviors;
using SchoolManagementSystem.Core.Features.Students.Commands.Models;
using SchoolManagementSystem.Core.Features.Students.Commands.Validators;
using SchoolManagementSystem.Core.Mapping;
using System.Reflection;

namespace SchoolManagementSystem.Core
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddModuleCoreDependencies(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(AddStudentCommand).Assembly);
            });
            //Mapster
            services.AddMapster();
            StudentMapping.RegisterStudentMapping();

            //Fluent validation
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //Fluent validation + MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(AddStudentValidator).Assembly);

            return services;
        }
    }
}
