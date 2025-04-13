
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TaskBoard_Api.Features.Tasks.Data;
using TaskBoard_Api.Features.Tasks.Repositories;
using TaskBoard_Api.Features.Tasks.Repositories.Interfaces;
using TaskBoard_Api.Features.Tasks.Services;
using TaskBoard_Api.Features.Tasks.Services.Interfaces;
using TaskBoard_Api.Features.Tasks.Validators;

namespace TaskBoard_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();

            builder.Services.AddValidatorsFromAssemblyContaining<CreateTaskDtoValidator>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference();
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
