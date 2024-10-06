using Laborotorna4.service;

namespace Laborotorna4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("files/books.json", optional: false).AddJsonFile("files/profiles.json", optional: false);

            builder.Services.AddTransient<BooksService>();
            builder.Services.AddTransient<ProfileService>();
            builder.Services.AddControllers();

            var app = builder.Build();

            
            app.MapControllers();
            app.MapGet("/", () => "/Library/");
            app.Run();
        }
    }
}
