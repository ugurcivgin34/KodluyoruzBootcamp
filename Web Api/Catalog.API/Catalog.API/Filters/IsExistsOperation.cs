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
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //metod prametrlerinden containskey id yoksa
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult("Id is required");
            }
            else
            {
                var id = (int)context.ActionArguments["id"];
                if (!await productService.IsProductExists(id))
                {
                    context.Result = new NotFoundObjectResult(new { message = $"{id} id'li ürün bulunamadı" });
                }
                else
                {
                    await next.Invoke();

                }
            }

           
        }
    }
}
