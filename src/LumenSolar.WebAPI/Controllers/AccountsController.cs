using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LumenSolar.WebAPI.Models.Doadores;
using LumenSolar.WebAPI.Models.Familias;
using LumenSolar.WebAPI.Data;
using Microsoft.AspNetCore.Authorization;

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
                Email = input.Email,
                UserName = input.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, input.Senha);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "Doador");

            Doador doador = new(input.Cpf, user);
            _context.Doador.Add(doador);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("registrar_familia")]
        public async Task<IActionResult> RegistrarFamilia([FromBody] RegistrarFamiliaInputModel input)
        {
            IdentityUser user = new()
            {
                Email = input.Email,
                UserName = input.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, input.Senha);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "Familia");


            FamiliaEndereco familiaEndereco = new(input.Cep, input.Rua, input.Numero, input.Bairro, input.Cidade, input.Uf);
            Familia familia = new(input.Cep, input.RendaMensal, 3, familiaEndereco, user);

            _context.Familia.Add(familia);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("registrar_admin")]
        [Authorize(Roles = "Admin")]  //Apenas Admins podem criar outros Admins.
        public async Task<IActionResult> RegistrarAdmin([FromBody] RegistrarAdminInputModel input)
        {
            IdentityUser user = new()
            {
                Email = input.Email,
                UserName = input.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, input.Senha);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Adiciona role ADMIN
            await _userManager.AddToRoleAsync(user, "Admin");

            return NoContent();
        }


    }
}
