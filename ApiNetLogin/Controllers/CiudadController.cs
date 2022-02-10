using ApiNetLogin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetLogin.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CiudadController : ControllerBase
    {

        [HttpGet("getAll")]
        public List<Ciudad> Get()
        {
            var lista = new List<Ciudad>();
            lista.Add(new Ciudad { Nombre = "Leon", Estado = "Guanajuato", Cp = 3700 });
            lista.Add(new Ciudad { Nombre = "Silao", Estado = "Guanajuato", Cp = 36100 });
            lista.Add(new Ciudad { Nombre = "Guanajuato", Estado = "Guanajuato", Cp = 3600 });
            lista.Add(new Ciudad { Nombre = "Irapuato", Estado = "Guanajuato", Cp = 36050 });
            return lista;
        }


        [HttpGet("getAuth")]
        [Authorize]
        public List<Ciudad> GetAuth()
        {
            var lista = new List<Ciudad>();
            lista.Add(new Ciudad { Nombre = "Mexico", Estado = "CDMX", Cp = 99999 });
            lista.Add(new Ciudad { Nombre = "Monterrey", Estado = "Nuevo Leon", Cp = 111111 });
            lista.Add(new Ciudad { Nombre = "Leon", Estado = "Guanajuato", Cp = 3700 });
            lista.Add(new Ciudad { Nombre = "Silao", Estado = "Guanajuato", Cp = 36100 });
            lista.Add(new Ciudad { Nombre = "Guanajuato", Estado = "Guanajuato", Cp = 3600 });
            lista.Add(new Ciudad { Nombre = "Irapuato", Estado = "Guanajuato", Cp = 36050 });
            return lista;
        }
    }
}
