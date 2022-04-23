using Catalog.Business;
using Catalog.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        //Asenkron zaman paylaşımlı , birbirinden bağımsız iş yapabilenler.Bir asenkron uygulama çalışırken başka bir uygulama 
        //eş zamanlı olarak çalışabilir

        public ProductsController(IProductService productService)
        {
            service = productService;     
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await service.GetProducts();
            return Ok(products);
        }
    }
}
