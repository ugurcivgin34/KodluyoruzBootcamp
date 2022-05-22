namespace Catalog.API.Middlewares
{
    public class ResponseEditingMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseEditingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Items["IE"] as bool?==true)  //boolean veri tipiyse ve true ise
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                

            }
            await _next(context);
        }
    }
}
