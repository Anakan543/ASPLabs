namespace Laborotorna3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<CalcService>();
            builder.Services.AddTransient<TimeOutput>();
            builder.Services.AddControllers();
            var app = builder.Build();

            app.MapControllers();
            app.Map("/", () => "/(operation => number1 = {x} numbers2 = {y}) \n/time/");
            app.Run();
        }
    }
}
