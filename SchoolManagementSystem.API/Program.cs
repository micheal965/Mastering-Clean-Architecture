using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolManagementSystem.API.Middlewares;
using SchoolManagementSystem.Core;
using SchoolManagementSystem.Infrastructure;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Service;
namespace SchoolManagementSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Localization
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddControllers()
                            .AddViewLocalization()
                            .AddDataAnnotationsLocalization();
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "Ar", "En" };
                options.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //Add Services
            builder.Services.AddInfrastructureDependencies()
                            .AddServiceDependencies()
                            .AddModuleCoreDependencies();
            var app = builder.Build();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //Localization
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
