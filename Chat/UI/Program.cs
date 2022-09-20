using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using UI.Helpers;

namespace UI
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

            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient();

            builder.Services.AddFluentValidationAutoValidation();

            ConfigureServices(builder);

            Validator(builder);

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.Configure<ApiConfiguration>(builder.Configuration.GetSection("ConnectionStrings"));
        }

        public static void Validator(WebApplicationBuilder builder)
        {
            //builder.Services.AddScoped<IValidator<l>, >();
        }
    }
}