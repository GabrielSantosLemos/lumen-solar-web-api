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
    [Route("api´/[controller]")]
    [Authorize(Roles ="Admin")] 
   
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
        public async Task<IActionResult> BuscarTodasFamilias()
        {
            List<FamiliaOutPutModel> familias = await _context.Familia
                .Include(itemFamilia => itemFamilia.Endereco)
                .Include(itemFamilia => itemFamilia.User)
                .Select(itemFamilia => new FamiliaOutPutModel
                {
                    Id = itemFamilia.Id,
                    Cpf = itemFamilia.Cpf,
                    RendaMensal = itemFamilia.RendaMensal,
                    NumeroIntegrantes = itemFamilia.NumeroIntegrantes,
                    Email = itemFamilia.User.Email,
                    Cidade = itemFamilia.Endereco.Cidade
                })
                .ToListAsync();

            return Ok(familias);
        }

        [HttpGet("Doadores")]
        public async Task<IActionResult> BuscarTodosDoadores()
        {
            List<DoadorOutPutModel> doadores = await _context.Doador
                .Include(itemDoador => itemDoador.User)
                .Select(itemDoador => new DoadorOutPutModel
                {
                    Id = itemDoador.Id,
                    Email = itemDoador.User.Email,
                    Cpf = itemDoador.Cpf
                })
                .ToListAsync();

                return Ok(doadores);
        }
    }

    
}
