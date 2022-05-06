using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransientScopedSingleton
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<ITransient,OperationService>(); //Her bir istekde yeni insteance al�yor
            services.AddScoped<IScoped,OperationService>();//Her bir istek ba��na bir adet insteance al�yor
            services.AddSingleton<ISingleton,OperationService>();//Uygulama ilk �al��t�r�ld���nda sadece bir adet insteance alarak
            //sonraki her �al��t�r�lma an�nda o alm�� oldu�u insteance yap�s� �st�nde ilerliyor 

            //Scoped yap�lan her bir istekle beraber bir insteance alarak i�lemlerini bu insteance �zerinden ger�ekle�tirirken
            //singleton yap�s� ise uygulama �al��t��� anda bir insteance al�p her istek bu insteance �zerinden ger�ekle�tirilmi� oluyor.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
