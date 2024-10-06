using Laborotorna6.Service;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Laborotorna6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseSerilog();
            // Add services to the container.
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"D:\\уник\\2024 первый семестр\\Розробка вебзастосунків на базі ASP.NET\\Projects\\Laborotorna6\\Logg.txt",
                outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}{NewLine}{Exception}").CreateLogger();

            builder.Services.AddControllersWithViews();
            
            var app = builder.Build();
           
            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
          /*  if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
          */
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
