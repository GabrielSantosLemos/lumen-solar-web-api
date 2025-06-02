using LumenSolar.WebAPI.Data;
using LumenSolar.WebAPI.Models.Doadores;
using LumenSolar.WebAPI.Models.Familias;
using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly Context _context;

        public AccountsController(TokenService tokenService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, Context context)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInputModel input)
        {
            IdentityUser? user = await _userManager.FindByEmailAsync(input.Email);
            if (user is null)
                return BadRequest("Usuário não existe.");

            Microsoft.AspNetCore.Identity.SignInResult checkPassword = await _signInManager.CheckPasswordSignInAsync(user, input.Senha, false);
            if (!checkPassword.Succeeded)
                return BadRequest("Senha Incorreta.");

            string token = await _tokenService.GerarToken(user);

            return Ok(token);
        }

        [HttpPost("registrar_doador")]
        public async Task<IActionResult> RegistrarDoador([FromBody] RegistrarDoadorInputModel input)
        {
            IdentityUser user = new()
            {
                Email = input.Doador.Email,
                UserName = input.Doador.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, input.Senha);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "Doador");

            Doador doador;

            if (input.Doador.Tipo == DoadorTipoEnum.Fisica)
            {
                doador = new(
                    input.Doador.NomeCompleto,
                    input.Doador.Celular,
                    input.Doador.Cpf,
                    user.Id);
            }
            else
            {
                doador = new(
                    input.Doador.NomeCompleto,
                    input.Doador.Celular,
                    input.Doador.NomeEmpresa,
                    input.Doador.Cnpj,
                    user.Id);
            }

            _context.Doador.Add(doador);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("registrar_familia")]
        public async Task<IActionResult> RegistrarFamilia([FromBody] RegistrarFamiliaInputModel input)
        {
            IdentityUser user = new()
            {
                Email = input.Familia.Email,
                UserName = input.Familia.Email,
            };

            IdentityResult result = await _userManager.CreateAsync(user, input.Senha);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "Familia");

            FamiliaEndereco endereco = new(input.Familia.Cep, input.Familia.Rua, input.Familia.Numero, input.Familia.Bairro, input.Familia.Cidade, input.Familia.Uf);
            
            Familia familia = new(
                input.Familia.NomeResponsavel,
                input.Familia.Cpf,
                input.Familia.Celular,
                input.Familia.RendaFamiliar,
                input.Familia.NumeroMoradores,
                input.Familia.GastoComEnergia,
                input.Familia.SituacaoVulnerabilidade,
                endereco,
                user.Id);

            _context.Familia.Add(familia);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
