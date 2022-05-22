using Catalog.Business;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Catalog.API.Security
{

    //Kişilere izin veren yapıyı oluşturuyor
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private readonly IUserService _userService;

        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder,
            ISystemClock systemClock,IUserService userService) : base(options, logger, encoder, systemClock)
        {
            _userService = userService;
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
            if (!headerValue.Scheme.Equals("Basic",StringComparison.OrdinalIgnoreCase)) //boşluktan sonrasını okumış olduk
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            //4. Authorization header,username/password doğru mu
            var bytes = Convert.FromBase64String(headerValue.Parameter);
            var creantials = Encoding.UTF8.GetString(bytes).Split(":");
            string username = creantials[0];
            string password = creantials[1];

            //Ziyaretci giriş kısmından girdi , güvenlik ziyaretçi kartı verdi içeri girmesine izin verdi
            var user = _userService.Validate(username, password);
            if (user!=null)
            {
                //TODO 1 : Geriye , claim ve token bilgisini döndür
                //Kişi hakkında tutulmak istenen herşey claimdir,iletişim bilgileri, doğum tarihi vs bunlar claimdir
                Claim[] claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("Gözrengi", user.FirstName)

                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);

                AuthenticationTicket ticket = new AuthenticationTicket(principal,Scheme.Name);
                return Task.FromResult(AuthenticateResult.Success(ticket));

            }

            return Task.FromResult(AuthenticateResult.Fail("Kullanıcı adı veya şifre hatalı"));
        }
    }
}
