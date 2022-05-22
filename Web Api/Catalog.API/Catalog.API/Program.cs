using Catalog.API.Extensions;
using Catalog.API.Middlewares;
using Catalog.API.Security;
using Catalog.Business;
using Catalog.Business.Mapping;
using Catalog.DataAccess.Data;
using Catalog.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IoC
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository, FakeUserRepository>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapProfile));

//catalogdbcontextin insteasýný almak için usesqlserver i kullanarak bbir option builder oluþturduk
builder.Services.AddDbContext<CatalogDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));
//opt.UseInMemoryDatabase//Geçiçi bir yapý, veri oluþturur hafýzada.daha sonra veritabnaý ile kullnýlýcaksa taþýnýr
builder.Services.AddCors(opt => opt.AddPolicy("allow", cpb =>
{
    cpb.AllowAnyOrigin();
    cpb.AllowAnyHeader();
    cpb.AllowAnyMethod();
    //cpb.WithMethods();//Belli adreslerden gelen istekler api ye eriþimi olsun istiyorsak

}));
builder.Services.AddMemoryCache();

var key = new SymmetricSecurityKey( Encoding.UTF8.GetBytes(builder.Configuration.GetSection("token:secret").Value));
//builder.Services.AddAuthentication("Basic").AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>("Basic",null);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                .AddJwtBearer(options =>
                                {
                                    options.SaveToken = true; //eðer authorization baþarýlý olursa ben bu üretilen token i sunucuda autencation property içinde saklarým
                                    options.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true ,
                                        ValidateAudience=true,
                                        ValidateActor=true,
                                        ValidIssuer = "u.civgin@gmail.com",
                                        ValidAudience ="u.civgin@gmail.com",
                                        IssuerSigningKey=key
                                    };
                                });


var app = builder.Build();

//app.UseWelcomePage(); //
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Talep,middleware tarafýndan yakalandý");
//});

////özel bir sayfaya talep gönderdiðimizde devireye alacaðýmýz middleware yazabiliyoruz
//app.Map("/test", middleBuilder =>
//{
//    middleBuilder.Run(async (ctx) =>
//    {
//        if (ctx.Request.Query.ContainsKey("id")) //eðer id isimde bir deðer varsa 
//        {
//            int id = int.Parse(ctx.Request.Query["id"]);
//            await ctx.Response.WriteAsync($"{id} deðeri ,middleware'a geldi");
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
//            await ctx.Response.WriteAsync($"id deðeri ,middleware'a gelmedi");

//        }
//    });
//});  //test gibi bir sayfaya gittiðinden ne yapmasýný söylüyoruz

// Configure the HTTP request pipeline.

//Yukarýdaki kod yerine , bu extension metot çaðrýlýyor.
app.UseProductIsExistTestPage(); //extension metodu yazdýk


app.Use( (ctx, next) =>
{
    Console.WriteLine($"{ctx.Request.Path} adresinden, {ctx.Request.Method} talebi geldi");
    return next();
});
//app.UseMiddleware<CheckBrowserIsIEMiddleware>(); //Bir middleware class olarak belirtip kullanmak için bu þekilde kullanýyoruz.
//app.UseMiddleware<ResponseEditingMiddleware>();
//app.UseMiddleware<RedirecMiddleware>();
app.UseCheckIE(); //Yukardakiler yerine extension metod yazarak kýsalttýk

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//use ile baþlayanlar genellikle middleware 
app.UseHttpsRedirection(); //gelene requestleri https adresine yönlendirecek
//Bu þekilde olmasaydý attribute ile her metodun üstüne giydirilerek yapýlabilirdi
app.UseStaticFiles();
app.UseCors("allow");

app.UseAuthentication();//Kimlik Kontrolü
app.UseAuthorization(); //Yetki kontrolü

app.MapControllers();

app.Run();
