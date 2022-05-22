using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;

namespace Catalog.API.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder,
            ISystemClock systemClock) : base(options, logger, encoder, systemClock)
        {

        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //1. Request içinde Authorization header var mı ?
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            //2.Authorization header doğru formatta mı ?
            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            //Request headers den authorization'u al eğer doğru ise headerValue olarak dışarı çıkar
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            //3.Authorization header Basic mi ?
            if (!headerValue.Scheme.Equals("Basic",StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            //4. Authorization header,username/password doğru mu
            var bytes = Convert.FromBase64String(headerValue.Parameter);
            var creantials = Encoding.UTF8.GetString(bytes).Split(":");
            string username = creantials[0];
            string password = creantials[1];

            if (username =="admin" && password=="admin")
            {
                //TODO 1 : Geriye , claim ve token bilgisini döndür
            }
        }
    }
}
