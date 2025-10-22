using LumenSolar.WebAPI.Data;
using LumenSolar.WebAPI.Models.PaineisSolares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/paineis-solares")]
    [ApiController]
    public class PaineisSolaresController : ControllerBase
    {
        private readonly Context _context;

        public PaineisSolaresController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var paineis = await _context.PainelSolar.ToListAsync();
            return Ok(paineis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var painel = await _context.PainelSolar.FindAsync(id);

            if (painel == null)
                return NotFound("Painel solar não encontrado.");

            return Ok(painel);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] PainelSolarInputModel input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var painel = new PainelSolar(
                input.Marca,
                input.Modelo,
                input.Potencia,
                input.Tensao,
                input.Corrente,
                input.Eficiencia,
                input.Localizacao);

            _context.PainelSolar.Add(painel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Buscar), new { id = painel.Id }, painel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] PainelSolarInputModel input, int id)
        {
            var painel = await _context.PainelSolar.FindAsync(id);

            if (painel == null)
                return NotFound("Painel solar não encontrado.");

            painel.Atualizar(
                input.Marca,
                input.Modelo,
                input.Potencia,
                input.Tensao,
                input.Corrente,
                input.Eficiencia,
                input.Localizacao);

            _context.PainelSolar.Update(painel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var painel = await _context.PainelSolar.FindAsync(id);

            if (painel == null)
                return NotFound("Painel solar não encontrado.");

            _context.PainelSolar.Remove(painel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
