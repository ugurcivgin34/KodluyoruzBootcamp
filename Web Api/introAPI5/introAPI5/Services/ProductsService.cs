using introAPI5.Models;

namespace introAPI5.Services
{
    public class ProductsService
    {
        private List<Product> products;
        public ProductsService()
        {
            products = new List<Product>
            {
              new Product {Id=1, Description="Product 1",Price=10,Discount=0.1,ImageUrl="https://picsum.photos/200/300",Name="Product 1",Stock=100 },
              new Product {Id=2, Description="Product 2",Price=20,Discount=0.1,ImageUrl="https://picsum.photos/200/300",Name="Product 1",Stock=100 },
              new Product {Id=3, Description="Product 3",Price=30,Discount=0.1,ImageUrl="https://picsum.photos/200/300",Name="Product 1",Stock=100 },
              new Product {Id=4, Description="Product 4",Price=40,Discount=0.1,ImageUrl="https://picsum.photos/200/300",Name="Product 1",Stock=100 },
              new Product {Id=5, Description="Product 5",Price=50,Discount=0.1,ImageUrl="https://picsum.photos/200/300",Name="Product 1",Stock=100 }
            };
        }

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.Find(x => x.Id == id);  
        }

        public void Create(Product product)
        {
            products.Add(product);
        }
    }
}
