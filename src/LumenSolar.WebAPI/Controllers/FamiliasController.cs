using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Mvc;
using LumenSolar.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/familias")]
    [ApiController]
    public class FamiliasController : ControllerBase
    {
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FamiliasController(Context context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarTodas()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] RegistrarFamiliaInputModel input)
        {
            if(input == null)
            {
                return BadRequest("Dados Inválidos");
            }

            //Cria o usuário com UserManager
            var user = new IdentityUser
            {
                Email = input.Email,
                UserName = input.Email
            };

            //Cria variavel para teste
            var result = await _userManager.CreateAsync(user, input.Senha);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Aqui ele vai criar endereço
            var endereco = new FamiliaEndereco(
               input.Cep,
               input.Rua,
               input.Numero,
               input.Bairro,
               input.Cidade,
               input.Uf   
            );

            //Cria família
            var familia = new Familia(
                input.Cpf,
                input.RendaMensal,
                3,
                endereco,
                user
            );

            _context.Familia.Add(familia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(BuscarTodas), new { id = familia.Id }, new {
                familia.Id,
                familia.Cpf,
                familia.RendaMensal,
                familia.NumeroIntegrantes,
                input.Email,
                input.Cidade
            });

        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> Atualizar([FromBody] RegistrarFamiliaInputModel input, int id)
        {
            var familia = await _context.Familia
                .Include(f => f.User)
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (familia == null)
                return NotFound("Família não encontrada.");

            familia.Cpf = input.Cpf;
            familia.RendaMensal = input.RendaMensal;
            familia.NumeroIntegrantes = input.NumeroIntegrantes;

            //Endereço
            familia.Endereco.Cep = input.Cep;
            familia.Endereco.Rua = input.Rua;
            familia.Endereco.Numero = input.Numero;
            familia.Endereco.Bairro = input.Bairro;
            familia.Endereco.Cidade = input.Cidade;
            familia.Endereco.Uf = input.Uf;

            if (familia.User.Email != input.Email)
            {
                familia.User.Email = input.Email;
                familia.User.UserName = input.Email;

                var result = await _userManager.UpdateAsync(familia.User);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);
            }

            _context.Familia.Update(familia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            var familia = await _context.Familia
                .Include(f => f.User)
                .Include(f => f.Endereco)
                .FirstOrDefaultAsync(f => f.Id == id);

            if( familia == null )
            
                return NotFound("Família não encontrada.");

            _context.Remove(familia.Endereco);

            _context.Familia.Remove(familia);

            var result = await _userManager.DeleteAsync(familia.User);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}