namespace Catalog.API.Middlewares
{
    public class CheckBrowserIsIEMiddleware //Hangi browser ile kullanılıyorsa api bunu middleware ile tespit edebilmek için bu classı oluşturduk
    {

        //Bir middleware başka bir middleware i alabilir.
        private readonly RequestDelegate _next; //gelen requesti aldık
        public CheckBrowserIsIEMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) //bu middleware ne yapmasını istiyorsak onu yaptırcak, glen request
        {
            var isIE = context.Request.Headers["User-Agent"].Any(value=>value.Contains("Trident"));//Gelen değer de Trident ifadesi yer alıyorsa internet explorer den geldiğini anlıyoruz
            context.Items["IE"]= isIE;
            context.Items["message"] = "Bu api istemcisi IE olamaz";
            //item: bir request'e eklenecek özel bilgilerdir.
            await _next.Invoke(context);
        }
    }
}
