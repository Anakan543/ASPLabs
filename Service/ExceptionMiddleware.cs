namespace Laborotorna6.Service
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                Console.WriteLine("Middleware працює. Запит обробляється...");
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка..");
                _logger.LogError(ex, ex.Message);
                await context.Response.WriteAsync("Error...");
            }
        }

    }
}
