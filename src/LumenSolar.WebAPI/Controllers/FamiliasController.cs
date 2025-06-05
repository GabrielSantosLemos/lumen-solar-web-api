using LumenSolar.WebAPI.Data;
using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/familias")]
    [ApiController]
    [Authorize(Roles = "familia")]
    public class FamiliasController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FamiliasController(Context context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            return Ok(_context.Familia.Include(x => x.Endereco).Include(x => x.User).Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] FamiliaInputModel input, int id)
        {
            Familia? familia = _context.Familia
                .Include(f => f.User)
                .Include(f => f.Endereco)
                .FirstOrDefault(f => f.Id == id);

            if (familia == null)
                return NotFound("Família não encontrada.");

            familia.Atualizar(
                input.NomeResponsavel,
                input.Cpf,
                input.Celular,
                input.RendaFamiliar,
                input.NumeroMoradores,
                input.GastoComEnergia,
                input.SituacaoVulnerabilidade);

            familia.Endereco.Atualizar(input.Cep, input.Rua, input.Numero, input.Bairro, input.Cidade, input.Uf);

            familia.PreAnaliseAutomatica();

            if (familia.User.Email != input.Email)
            {
                familia.User.Email = input.Email;
                familia.User.UserName = input.Email;

                IdentityResult result = await _userManager.UpdateAsync(familia.User);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);
            }

            _context.Familia.Update(familia);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}