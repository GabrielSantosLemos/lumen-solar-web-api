namespace LumenSolar.WebAPI.Models.Familias
{
    public class FamiliaInputModel
    {
        public string NomeResponsavel { get; set; }
        public decimal RendaMensal { get; set; }
        public int NumeroIntegrantes { get; set; }
        public string Cpf { get; set; }
    }
}
