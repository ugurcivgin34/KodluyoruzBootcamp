using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalog.API.Filters
{
    public class IsExistsAttribute : TypeFilterAttribute
    {
        //Attribute ler depency enjection ile olmuyor.Çünkü insteance alamıyoruz
        public IsExistsAttribute():base(typeof(IsExistsOperation))
        {

        }
    }
}
