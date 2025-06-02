using LumenSolar.WebAPI.Data;
using LumenSolar.WebAPI.Models.Doadores;
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

    [HttpGet("{id}")]
    public IActionResult Buscar(int id)
    {
        return Ok(_context.Doador.Include(x => x.Doacoes).Include(x => x.User).Where(x => x.Id == id).FirstOrDefault());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar([FromBody] DoadorInputModel input, int id)
    {
        Doador? doador = _context.Doador.Include(f => f.User)
                                        .FirstOrDefault(x => x.Id == id);

        if (doador == null)
            return NotFound("Doador não encontrado.");

        if (doador.Tipo == DoadorTipoEnum.Fisica)
        {
            doador.Atualizar(
                input.NomeCompleto,
                input.Celular,
                input.Cpf);
        }
        else
        {
            doador.Atualizar(
                input.NomeCompleto,
                input.Celular,
                input.NomeEmpresa,
                input.Cnpj
                );
        }

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

    [HttpPost("{doadorId}/doar")]
    public IActionResult Doar([FromBody] DoarInputModel input, int doadorId)
    {
        Doacao doacao = new(input.Valor, DateTime.Now, doadorId);
        _context.Doacao.Add(doacao);
        _context.SaveChanges();

        return Ok();
    }

    [HttpGet("{doadorId}/doacoes")]
    public IActionResult DoacaoBuscarTodas(int doadorId)
    {
        return Ok(_context.Doacao.Where(x => x.DoadorId == doadorId));
    }
}
