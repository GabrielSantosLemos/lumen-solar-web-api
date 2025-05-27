using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Mvc;
using LumenSolar.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/familias")]
    [ApiController]
    public class FamiliasController : ControllerBase
    {
        private readonly Context _context;

        public FamiliasController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodas()
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