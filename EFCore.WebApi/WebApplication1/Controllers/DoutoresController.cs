using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DoutoresController : ControllerBase
    {
        DoutorRepository doutorRepository = new DoutorRepository();

        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(doutorRepository.Listar());
        }
        [HttpPost]
        public ActionResult Cadastrar(Doutores doutor)
        {
            try
            {
                doutorRepository.Cadastrar(doutor);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public void Excluir(int id)
        {
            try
            {
            doutorRepository.Deletar(id);
            }
            catch(Exception ex)
            {
               BadRequest(new { mensagem = ex.Message });

            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Doutores doutor, int id)
        {
            try
            {
                Doutores categoriaBuscada = doutorRepository.BuscarPorId(id);
                if (categoriaBuscada == null)
                    return NotFound();
                doutorRepository.Atualizar(doutor, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }



    }
}
