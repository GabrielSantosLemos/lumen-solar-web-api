using LumenSolar.WebAPI.Models.Doadores;
using Microsoft.AspNetCore.Mvc;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/doadores")]
    [ApiController]
    public class DoadoresController : ControllerBase
    {

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Inserir([FromBody] Doador input)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar([FromBody] Doador input, int id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            return NoContent();
        }
    }
}
