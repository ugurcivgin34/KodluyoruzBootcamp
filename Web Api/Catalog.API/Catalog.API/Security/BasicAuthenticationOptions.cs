using Microsoft.AspNetCore.Authentication;

namespace Catalog.API.Security
{

    //Authentication işlemlerini nereye yönlendircek,varsayılan bilgileri saklar
    public class BasicAuthenticationOptions  : AuthenticationSchemeOptions
    {
        public BasicAuthenticationOptions()
        {
            
        }
    }
}
