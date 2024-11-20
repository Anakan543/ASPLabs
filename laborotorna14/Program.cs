using Laborotorna14.Exporter;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
//
namespace Laborotorna14
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Seq("http://localhost:5341", apiKey: "eO0jCI5JsAAMFHL3lizn")
            .CreateLogger();



            builder.Host.UseSerilog();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddOpenTelemetry().
                WithTracing(tracing => tracing
                    .AddSource("Laborotorna14")
                  .AddAspNetCoreInstrumentation()
                  .AddHttpClientInstrumentation()
                  .AddConsoleExporter()
                   
                  .AddProcessor(new BatchActivityExportProcessor(new SerilogExporterTracing()))
                  .AddOtlpExporter(o =>
                  {
                      o.Endpoint = new Uri("http://localhost:4317");
                  })
              )
                  .WithMetrics(metrics => metrics
                  .AddAspNetCoreInstrumentation()
                  .AddRuntimeInstrumentation()
                  .AddConsoleExporter()
                  //.aDD
                  // .AddProcessor(new BatchActivityExportProcessor(new SerilogExporterTracing()))
                  .AddReader(new PeriodicExportingMetricReader(new SerilogExporterMetrics()))
                  .AddOtlpExporter(o =>
                  {
                      o.Endpoint = new Uri("http://localhost:4317");
                  })
                );
           
            //Tags tags = new Tags();
            //tags.TagsProcess();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapGet("/process", () =>
            {
                Tags tags = new Tags();
                tags.TagsProcess();
                return Results.Ok("Request processed");
            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
