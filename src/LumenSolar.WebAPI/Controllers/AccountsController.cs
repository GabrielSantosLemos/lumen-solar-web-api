using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LumenSolar.WebAPI.Models.Doadores;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountsController(TokenService tokenService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInputModel input)
        {
            User? user = await _userManager.FindByEmailAsync(input.Email);
            if (user is null)
                return BadRequest("Usuário não existe.");

            Microsoft.AspNetCore.Identity.SignInResult checkPassword = await _signInManager.CheckPasswordSignInAsync(user, input.Senha, false);
            if (!checkPassword.Succeeded)
                return BadRequest("Senha Incorreta.");

            string token = await _tokenService.GerarToken(user);

            return Ok(token);
        }

       
    }
}
