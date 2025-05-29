using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LumenSolar.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using LumenSolar.WebAPI.Models.Doadores;
using Microsoft.AspNetCore.Authorization;

namespace LumenSolar.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]

    public class AdminController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(UserManager<IdentityUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet("Familias")]
        public IActionResult BuscarTodasFamilias()
        {
            List<Familia> familias = _context.Familia
                .Include(itemFamilia => itemFamilia.Endereco)
                .Include(itemFamilia => itemFamilia.User)
                .ToList();

            return Ok(familias);
        }

        [HttpGet("Doadores")]
        public IActionResult BuscarTodosDoadores()
        {
            List<Doador> doadores = _context.Doador
                .Include(itemDoador => itemDoador.User)
                .ToList();

            return Ok(doadores);
        }
    }
}
