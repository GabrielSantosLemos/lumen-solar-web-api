using LumenSolar.WebAPI.Models.Doadores;
using Microsoft.AspNetCore.Mvc;
using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using LumenSolar.WebAPI.Data;
using System.Linq.Expressions;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/doadores")]
    [ApiController]
    public class DoadoresController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DoadoresController(Context context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodas()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] RegistrarDoadorInputModel input)
        {
            if (input == null)
            {
                return BadRequest("Dados Inválidos");
            }

            //Cria usuário com UserManager
            var user = new IdentityUser
            {
                Email = input.Email,
                UserName = input.Email
            };

            //Cria variável para teste
            var result = await _userManager.CreateAsync(user, input.Senha);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            //Cria Doador
            var doador = new Doador(
                
             input.Cpf,
             user
             );

            _context.Doador.Add(doador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscarTodas), new { id = doador.Id }, new { 
            
            doador.Id,
            doador.Cpf,
            input.Email
            });
      
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromBody] RegistrarDoadorInputModel input, int id)
        {
            var doador = await _context.Doador
               .Include(f => f.User)
               .FirstOrDefaultAsync(f => f.Id == id);

            if (doador == null)
                return NotFound("Doador não encontrado.");

            doador.Cpf = input.Cpf;
            //Terá NomeCompleto aqui 

            if (doador.User.Email != input.Email)
            {
                doador.User.Email = input.Email;
                doador.User.UserName = input.Email;

                var result = await _userManager.UpdateAsync(doador.User);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);
            }

            _context.Doador.Update(doador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var doador = await _context.Doador
                .Include(f => f.User)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (doador == null)
                return NotFound("Doador não encontrado.");

            _context.Doador.Remove(doador);

            var result = await _userManager.DeleteAsync(doador.User);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{doadorId}/doacoes")]
        public IActionResult BUscarTodasDoacoes(int doadorId)
        {
            List<Doacao> doacoes = new()
            {
                new Doacao(10.50m, DateTime.Now),
                new Doacao(62.50m, DateTime.Now),
                new Doacao(30.20m, DateTime.Now),
                new Doacao(80.10m, DateTime.Now),
                new Doacao(60.30m, DateTime.Now),
            };

            return Ok(doacoes);
        }
    }
}
