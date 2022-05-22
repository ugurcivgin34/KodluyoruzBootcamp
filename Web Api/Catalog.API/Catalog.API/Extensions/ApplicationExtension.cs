using Catalog.API.Middlewares;
using Catalog.Business;

namespace Catalog.API.Extensions
{
    public static class ApplicationExtension
    {

        public static void UseCheckIE(this IApplicationBuilder app)
        {
            app.UseMiddleware<CheckBrowserIsIEMiddleware>(); //Bir middleware class olarak belirtip kullanmak için bu şekilde kullanıyoruz.
            app.UseMiddleware<ResponseEditingMiddleware>();
            app.UseMiddleware<RedirecMiddleware>();
        }
        public static void UseProductIsExistTestPage(this IApplicationBuilder app)
        {
            //özel bir sayfaya talep gönderdiğimizde devireye alacağımız middleware yazabiliyoruz
            app.Map("/test", middleBuilder =>
            {
                middleBuilder.Run(async (ctx) =>
                {
                    if (ctx.Request.Query.ContainsKey("id")) //eğer id isimde bir değer varsa 
                    {
                        int id = int.Parse(ctx.Request.Query["id"]);
                        await ctx.Response.WriteAsync($"{id} değeri ,middleware'a geldi");
                        using var scope = middleBuilder.ApplicationServices.CreateScope();
                        var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
                        if (await productService.IsProductExists(id))
                        {
                            await ctx.Response.WriteAsync($"{id} degeri ,db'de var");

                        }
                        else
                        {
                            await ctx.Response.WriteAsync($"{id} degeri ,db'de yok");

                        }
                    }
                    else
                    {
                        await ctx.Response.WriteAsync($"id değeri ,middleware'a gelmedi");

                    }
                });
            });  //test gibi bir sayfaya gittiğinden ne yapmasını söylüyoruz
        }
    }
}
