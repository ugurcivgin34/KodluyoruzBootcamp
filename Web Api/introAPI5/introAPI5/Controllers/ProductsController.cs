using introAPI5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace introAPI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product{ Id=1,Name="Product 1",Description="Product 1 description",Price=10,CategoryId=1,ImageUrl="https://picsum.photos/2022"},
                new Product{ Id=1,Name="Product 1",Description="Product 1 description",Price=10,CategoryId=1,ImageUrl="https://picsum.photos/2022"},
                new Product{ Id=1,Name="Product 1",Description="Product 1 description",Price=10,CategoryId=1,ImageUrl="https://picsum.photos/2022"},
                new Product{ Id=1,Name="Product 1",Description="Product 1 description",Price=10,CategoryId=1,ImageUrl="https://picsum.photos/2022"}
            };
            return Ok(products);
        }
    }
}
