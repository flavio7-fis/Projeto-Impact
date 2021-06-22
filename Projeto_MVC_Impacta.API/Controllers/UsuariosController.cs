using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_MVC_Impacta.API.Services;
using Projeto_MVC_Impacta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_MVC_Impacta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { api = true });
        }

        public IActionResult Post([FromBody]Usuarios usuario, [FromServices]UsuariosServices services)
        {
            if (ModelState.IsValid)
            {
                return Ok(services.AddUsuario(usuario));
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
