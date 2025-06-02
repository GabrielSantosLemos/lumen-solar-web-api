namespace LumenSolar.WebAPI.Models
{
    public class DashboardsViewModel
    {
        public int TotalFamiliasAjudadas { get; set; }
        public int TotalPlacasSolaresAdquiridas { get; set; }
        public decimal TotalValorDoacaoRecebidas { get; set; }
        public decimal TotalValorContasPagas { get; set; }
        public List<ContasPagasPorEstadoDto> ContasPagasPorEstado { get; set; }
    }

    public class ContasPagasPorEstadoDto
    {
        public string Uf { get; set; }         // Ex: "SP"
        public decimal ValorTotal { get; set; } // Ex: 1500.00
    }
}
