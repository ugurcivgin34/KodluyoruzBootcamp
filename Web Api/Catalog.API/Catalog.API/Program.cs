using Catalog.Business;
using Catalog.Business.Mapping;
using Catalog.DataAccess.Data;
using Catalog.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IoC
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IProductRepository,EfProductRepository>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MapProfile));

//catalogdbcontextin insteas�n� almak i�in usesqlserver i kullanarak bbir option builder olu�turduk
builder.Services.AddDbContext<CatalogDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("db")));
//opt.UseInMemoryDatabase//Ge�i�i bir yap�, veri olu�turur haf�zada.daha sonra veritabna� ile kulln�l�caksa ta��n�r


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
