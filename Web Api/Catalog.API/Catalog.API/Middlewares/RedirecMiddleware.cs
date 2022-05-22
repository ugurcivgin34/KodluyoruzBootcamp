namespace Catalog.API.Middlewares
{
    public class RedirecMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirecMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Response.StatusCode==StatusCodes.Status400BadRequest)
            {
              await  context.Response.WriteAsync(context.Items["message"].ToString());
            }
            await _next(context);
        }
    }
}
