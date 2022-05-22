using Catalog.API.Extensions;
using Catalog.API.Middlewares;
using Catalog.Business;
using Catalog.Business.Mapping;
using Catalog.DataAccess.Data;
using Catalog.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IoC
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapProfile));

//catalogdbcontextin insteas�n� almak i�in usesqlserver i kullanarak bbir option builder olu�turduk
builder.Services.AddDbContext<CatalogDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));
//opt.UseInMemoryDatabase//Ge�i�i bir yap�, veri olu�turur haf�zada.daha sonra veritabna� ile kulln�l�caksa ta��n�r
builder.Services.AddCors(opt => opt.AddPolicy("allow", cpb =>
{
    cpb.AllowAnyOrigin();
    cpb.AllowAnyHeader();
    cpb.AllowAnyMethod();
    //cpb.WithMethods();//Belli adreslerden gelen istekler api ye eri�imi olsun istiyorsak
}));

builder.Services.AddAuthentication("Basic").AddScheme<>


var app = builder.Build();

//app.UseWelcomePage(); //
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Talep,middleware taraf�ndan yakaland�");
//});

////�zel bir sayfaya talep g�nderdi�imizde devireye alaca��m�z middleware yazabiliyoruz
//app.Map("/test", middleBuilder =>
//{
//    middleBuilder.Run(async (ctx) =>
//    {
//        if (ctx.Request.Query.ContainsKey("id")) //e�er id isimde bir de�er varsa 
//        {
//            int id = int.Parse(ctx.Request.Query["id"]);
//            await ctx.Response.WriteAsync($"{id} de�eri ,middleware'a geldi");
//            using var scope = middleBuilder.ApplicationServices.CreateScope();
//            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
//            if (await productService.IsProductExists(id))
//            {
//                await ctx.Response.WriteAsync($"{id} degeri ,db'de var");

//            }
//            else
//            {
//                await ctx.Response.WriteAsync($"{id} degeri ,db'de yok");

//            }
//        }
//        else
//        {
//            await ctx.Response.WriteAsync($"id de�eri ,middleware'a gelmedi");

//        }
//    });
//});  //test gibi bir sayfaya gitti�inden ne yapmas�n� s�yl�yoruz

// Configure the HTTP request pipeline.

//Yukar�daki kod yerine , bu extension metot �a�r�l�yor.
app.UseProductIsExistTestPage(); //extension metodu yazd�k


app.Use( (ctx, next) =>
{
    Console.WriteLine($"{ctx.Request.Path} adresinden, {ctx.Request.Method} talebi geldi");
    return next();
});
//app.UseMiddleware<CheckBrowserIsIEMiddleware>(); //Bir middleware class olarak belirtip kullanmak i�in bu �ekilde kullan�yoruz.
//app.UseMiddleware<ResponseEditingMiddleware>();
//app.UseMiddleware<RedirecMiddleware>();
app.UseCheckIE(); //Yukardakiler yerine extension metod yazarak k�saltt�k

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//use ile ba�layanlar genellikle middleware 
app.UseHttpsRedirection(); //gelene requestleri https adresine y�nlendirecek
//Bu �ekilde olmasayd� attribute ile her metodun �st�ne giydirilerek yap�labilirdi
app.UseStaticFiles();
app.UseCors("allow");

app.UseAuthentication();//Kimlik Do�rulama
app.UseAuthorization(); //Yetki kontrol�

app.MapControllers();

app.Run();
