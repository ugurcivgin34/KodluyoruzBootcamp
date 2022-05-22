using Catalog.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalog.API.Filters
{
    public class IsExistsOperation : IAsyncActionFilter
    {
        private readonly IProductService productService;

        public IsExistsOperation(IProductService productService)
        {
            this.productService=productService; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">Controller içinde bir action var,o actionun bütün bilgilerini context ile ulaşabiliriz .Yani controllerde neyin üstünde arttibute şeklinde yazdıysak herşeyi context tutar</param>
        /// <param name="next">İşlem tamamlandıktan sonra ne yapmak istiyoruz</param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //metod prametrlerinden containskey id yoksa
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("Id is required");
            }
            else
            {
                //Böyle bir id varsa o zaman bu id değerini al
                var id = (int)context.ActionArguments["id"];
                if (!await productService.IsProductExists(id))
                {
                    context.Result = new NotFoundObjectResult(new { message = $"{id} id'li ürün bulunamadı" }); //böyle ürün yoksa 
                }
                else
                {
                    await next.Invoke(); //varsa invoke et

                }
            }

           
        }
    }
}
