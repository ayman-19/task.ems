using System.Reflection;
using Microsoft.OpenApi.Models;
using task.ems.api.Middlewares;
using task.ems.bll;
using task.ems.dal;

namespace task.ems.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo { Title = "task.emp.api", Version = "v1" }
                );

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder
                .Services.RegisterDALDependencies(builder.Configuration)
                .RegisterBLLDependencies(builder.Configuration)
                .AddScoped<ExceptionHandler>();

            var app = builder.Build();
            app.UseMiddleware<ExceptionHandler>();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
