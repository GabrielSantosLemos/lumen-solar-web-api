using LumenSolar.WebAPI.Data;
using LumenSolar.WebAPI.Models;
using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LumenSolar.WebAPI.Controllers
{
    [Route("api/dashboards")]
    [ApiController]
    public class DashboardsController : ControllerBase
    {
        private readonly Context _context;

        public DashboardsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            DashboardsViewModel dto = new()
            {
                TotalFamiliasAjudadas = _context.Familia.Where(x => x.Status == StatusEnum.Apto).Count(),
                TotalPlacasSolaresAdquiridas = 562,
                TotalValorContasPagas = _context.Familia.Where(x => x.Status == StatusEnum.Apto).Sum(x => x.GastoComEnergia),
                TotalValorDoacaoRecebidas = _context.Doacao.Sum(x => x.Valor)
            };

            List<ContasPagasPorEstadoDto> contasPagasPorEstado = _context.Familia
                .Where(f => f.Status == StatusEnum.Apto)
                .GroupBy(f => f.Endereco.Uf.ToLower())
                .Select(g => new ContasPagasPorEstadoDto
                {
                    Uf = $"br-{g.Key}",
                    ValorTotal = g.Sum(f => f.GastoComEnergia)
                })
                .ToList();

            dto.ContasPagasPorEstado = contasPagasPorEstado;

            return Ok(dto);
        }
    }
}
