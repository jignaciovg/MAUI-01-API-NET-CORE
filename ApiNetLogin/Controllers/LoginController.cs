using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNetLogin.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost ("Auth")]
        public Models.Login Post([FromBody] Models.UserMin user)
        {
            Models.Login result = new Models.Login();

            // pass = "hola"
            var pass = "b221d9dbb083a7f33428d7c2a3c3198ae925614d70210e28716ccaa7cd4ddb79"; 
            if (user.Password == pass && user.Nick == "nacho")
            {
                //CREACION DE JWT
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("maestria-mtwdm-2022"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://plataforma.poderjudicial-gto.gob.mx",
                    audience: "https://plataforma.poderjudicial-gto.gob.mx",
                    claims: new List<System.Security.Claims.Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
               );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                result = new Models.Login()
                {
                    Token = tokenString,
                    ID = 1,
                    Name = user.Nick
                };
                return result;
            }
            else
            {
                return result;
            }
        }

    }
}
