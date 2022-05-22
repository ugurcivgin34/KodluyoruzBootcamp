
using Catalog.API.Models;
using Catalog.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.Validate(model.UserName, model.Password);
                if (user!=null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Role),
                    };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature); //salting

                    var token = new JwtSecurityToken(
                        issuer:"u.civgin@gmail.com",  //tokena erişecek olan , yani kim tarafındna erişecekse yayıncı kim ise onu yazıyoruz
                        audience: "u.civgin@gmail.com" , //Bu yayıncıyı kim kullanacak
                        claims: claims,
                        notBefore:DateTime.Now,//şuandan önce kullanılamaz,
                        expires:DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials //token doğrulama
                        );
                    return Ok(new {token=new JwtSecurityTokenHandler().WriteToken(token)});
                }
                else
                {
                    return Unauthorized();
                }
            }
            return BadRequest(ModelState);
        }
    }
}
