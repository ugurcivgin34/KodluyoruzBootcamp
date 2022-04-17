using introAPI5.Models;
using introAPI5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace introAPI5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products;

        private ProductsService productsService;
        public ProductsController()
        {
            productsService = new ProductsService();


        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = productsService.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            //Model Binder , Http request body'sinden gelen verileri Product nesnesine dönüştürür.
            if (ModelState.IsValid) //İlgili action yani product eğerki herşey yolundayse
            {
                //return Created("http://www.myproducts.com/products/1", product);  //işlem başarılı , eklemek istediği locasyon burası demiş olduk .

                productsService.Create(product);
                return CreatedAtAction(nameof(GetProduct), routeValues: new { id=5},value:product);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct([FromRoute]int id)
        {
            //var product = products.Find(x => x.Id == id); //predicate dediği eşleme kuralları olan bir func tion dır.
            var product = productsService.GetById(id);
            if (product == null)
            {
                return NotFound(new { message = $"{id} numaralı ürün bulunamadı" });
            }
            return Ok(product);
        }

        //[HttpGet]
        //public IActionResult SearchProductByName(string name)
        //{
        //    return Ok();
        //}
    }
}
