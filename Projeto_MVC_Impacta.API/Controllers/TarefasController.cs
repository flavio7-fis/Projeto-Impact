using Microsoft.AspNetCore.Authorization;
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
    public class TarefasController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetAll([FromServices] TarefasService tarefas)
        {
            return Ok(tarefas.GetTarefas());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetAll(Guid id, [FromServices] TarefasService tarefas)
        {
            return Ok(tarefas.GetTarefasById(id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add([FromBody] Tarefas request, [FromServices] TarefasService tarefas)
        {
            if (ModelState.IsValid)
            {
                return Ok(tarefas.AddTarefas(request));
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] Tarefas request, [FromServices] TarefasService tarefas)
        {
            if (ModelState.IsValid)
            {
                return Ok(tarefas.UpdateTarefa(request));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(Guid id, [FromServices] TarefasService tarefas)
        {
            return Ok(tarefas.RemoveTarefasById(id));
        }
    }
}
