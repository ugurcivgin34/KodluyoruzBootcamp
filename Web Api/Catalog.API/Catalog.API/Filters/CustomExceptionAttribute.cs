using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalog.API.Filters
{
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        public string ErrorMessage { get; set; }
        //Hangi metotun üstünde yazılırsa  o metod hata verirse çalışcak
        public override void OnException(ExceptionContext context)
        {
            string errorMessage = ErrorMessage ?? context.Exception.Message; //Eğer error message dolu ise kullanmak mesaj bu , değilse o hatanın mesajını yaz
            context.Result = new BadRequestObjectResult(new { message = errorMessage });
            base.OnException(context);
        }
    }
}
