using API.DTOs.Comment;
using API.Helpers.Comment;
using Application.Services.Comment;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebBuilder(args).Run();
        }
        public static WebApplication WebBuilder(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddFluentValidationAutoValidation();

            ConfigureServices(builder);

            Validator(builder);

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI();
            }

            app.MapControllers();

            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<IDbContext, ChatContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<ICommentService, CommentService>();
        }

        public static void Validator(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<CreateCommentDto>, CreateCommentDtoValidator>();
        }
    }
}
