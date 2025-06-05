using LumenSolar.WebAPI.Data;
using LumenSolar.WebAPI.Models.Doadores;
using LumenSolar.WebAPI.Models.Familias;
using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AtualizarStatus
{
    public StatusEnum Status { get; set; }
}

namespace LumenSolar.WebAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(Context context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("familias")]
        public IActionResult FamiliasBuscarTodas()
        {
            List<Familia> familias = _context.Familia
                .Include(x => x.Endereco)
                .Include(x => x.User)
                .OrderBy(x => x.Id)
                .ToList();

            return Ok(familias);
        }

        [HttpDelete("familias/{id}")]
        public async Task<IActionResult> FamiliasExcluir( int id)
        {
            Familia? familia = _context.Familia.Where(x => x.Id == id).FirstOrDefault();
            if (familia == null)
                return BadRequest();

            _context.Familia.Remove(familia);
            _context.SaveChanges();

            IdentityUser? user = await _userManager.FindByIdAsync(familia.UserId);
            if (user != null)
                await _userManager.DeleteAsync(user);

            return NoContent();
        }

        [HttpPost("familias/{id}/status")]
        public IActionResult FamiliasAtualizarStatus([FromBody] AtualizarStatus input, int id)
        {
            Familia? familia = _context.Familia.Where(x => x.Id == id).FirstOrDefault();
            if (familia == null)
                return BadRequest();

            familia.AtualizarStatus(input.Status);

            _context.Familia.Update(familia);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("doadores")]
        public IActionResult DoadoresBuscarTodos()
        {
            List<Doador> doadores = _context.Doador
                .Include(x => x.User)
                .OrderBy(x => x.Id)
                .ToList();

            return Ok(doadores);
        }

        [HttpDelete("doadores/{id}")]
        public async Task<IActionResult> DoadoresExcluirAsync(int id)
        {
            Doador? doador = _context.Doador.Where(x => x.Id == id).FirstOrDefault();
            if (doador == null)
                return BadRequest();

            _context.Doador.Remove(doador);
            _context.SaveChanges();

            IdentityUser? user = await _userManager.FindByIdAsync(doador.UserId);
            if (user != null)
                await _userManager.DeleteAsync(user);

            return NoContent();
        }
    }
}
