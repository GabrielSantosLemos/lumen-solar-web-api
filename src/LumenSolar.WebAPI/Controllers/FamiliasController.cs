using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Mvc;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/familias")]
    [ApiController]
    public class FamiliasController : ControllerBase
    {
        [HttpGet]
        public IActionResult BuscarTodas()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] Familia input)
        {
            return NoContent();
        }

        [HttpPut("/{id}")]
        public IActionResult Atualizar([FromBody] Familia input, int id)
        {
            return NoContent();
        }

        [HttpDelete("/{id}")]
        public IActionResult Excluir(int id)
        {


            return NoContent();
        }
    }
}