using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        PacienteRepository pacienteRepository = new PacienteRepository();

        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(pacienteRepository.Listar());
        }
        [HttpPost]
        public ActionResult Cadastrar(Pacientes paciente)
        {
            try
            {
                pacienteRepository.Cadastrar(paciente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public void Excluir(int id)
        {
            
            pacienteRepository.Deletar(id);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Pacientes paciente, int id)
        {
            try
            {
                Pacientes pacienteBuscado = pacienteRepository.BuscarPorId(id);
                if (pacienteBuscado == null)
                    return NotFound();
                pacienteRepository.Atualizar(paciente, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }



    }
}
