using LumenSolar.WebAPI.Data;
using LumenSolar.WebAPI.Models.Doadores;
using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LumenSolar.WebAPI.Controllers;

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
        IdentityUser user = new()
        {
            Email = input.Email,
            UserName = input.Email
        };

        IdentityResult result = await _userManager.CreateAsync(user, input.Senha);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        Doador doador = new(input.Cpf, user);

        _context.Doador.Add(doador);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar([FromBody] RegistrarDoadorInputModel input, int id)
    {
        Doador? doador = _context.Doador
           .Include(f => f.User)
           .FirstOrDefault(x => x.Id == id);

        if (doador == null)
            return NotFound("Doador não encontrado.");

        doador.Cpf = input.Cpf;

        if (doador.User.Email != input.Email)
        {
            doador.User.Email = input.Email;
            doador.User.UserName = input.Email;

            IdentityResult result = await _userManager.UpdateAsync(doador.User);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
        }

        _context.Doador.Update(doador);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(int id)
    {
        Doador? doador = _context.Doador
            .Include(f => f.User)
            .FirstOrDefault(f => f.Id == id);

        if (doador == null)
            return NotFound("Doador não encontrado.");

        _context.Doador.Remove(doador);

        IdentityResult result = await _userManager.DeleteAsync(doador.User);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        _context.SaveChanges();

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

