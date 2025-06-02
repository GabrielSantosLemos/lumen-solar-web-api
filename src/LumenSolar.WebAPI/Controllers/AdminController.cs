using LumenSolar.WebAPI.Data;
using LumenSolar.WebAPI.Models.Doadores;
using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LumenSolar.WebAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    //[Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly Context _context;

        public AdminController(Context context)
        {
            _context = context;
        }

        [HttpGet("familias")]
        public IActionResult FamiliasBuscarTodas()
        {
            List<Familia> familias = _context.Familia
                .Include(x => x.Endereco)
                .Include(x => x.User)
                .ToList();

            return Ok(familias);
        }

        [HttpGet("doadores")]
        public IActionResult DoadoresBuscarTodos()
        {
            List<Doador> doadores = _context.Doador
                .Include(x => x.User)
                .ToList();

            return Ok(doadores);
        }
    }
}
