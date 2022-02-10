using ApiNetLogin.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiNetLogin.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IToken tokenService;
        public LoginController(IToken tokenService)
        {
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost ("Auth")]
        public Models.Login Post([FromBody] Models.UserMin user)
        {
            Models.Login result = new Models.Login();
            var pass = "hola";
            //var pass = "b221d9dbb083a7f33428d7c2a3c3198ae925614d70210e28716ccaa7cd4ddb79"; 
            if (user.Password == pass && user.Nick == "nacho")
            {
                //CREACION DE JWT

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nick)
                };

                var tokenString = tokenService.GenerateAccessToken(claims);

                // token generado
                //eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoibmFjaG8iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc3VhcmlvIiwiZXhwIjoxNjQ0NDY5MjQ4LCJpc3MiOiJodHRwczovL3BsYXRhZm9ybWEucG9kZXJqdWRpY2lhbC1ndG8uZ29iLm14IiwiYXVkIjoiaHR0cHM6Ly9wbGF0YWZvcm1hLnBvZGVyanVkaWNpYWwtZ3RvLmdvYi5teCJ9.cG-FzjQyY0KuqxBIFJj97cxN0MqbU7PnjzPzu6eyyX4

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
