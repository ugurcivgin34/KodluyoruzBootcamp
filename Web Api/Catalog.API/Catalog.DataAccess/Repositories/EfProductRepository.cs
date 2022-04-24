using Catalog.DataAccess.Data;
using Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAccess.Repositories
{
    public class EfProductRepository : IProductRepository
    {

        private CatalogDbContext context;

        public EfProductRepository(CatalogDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Product entity)
        {
            await context.AddAsync(entity); //Belleğe ekleme yapıyor sadece..Persister api paterni,yani işleri biriktirip topluca veritabanında çalıştırmak
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product=await context.Products.FirstOrDefaultAsync(p => p.Id == id);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<IList<Product>> GetAll()
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            return await context.Products.FindAsync(id);


        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await context.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await context.Products.AnyAsync(p => p.Id == id); //var mı yok mu onu kontrol ediyor
        }

        public async Task Update(Product entity)
        {
            context.Products.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
