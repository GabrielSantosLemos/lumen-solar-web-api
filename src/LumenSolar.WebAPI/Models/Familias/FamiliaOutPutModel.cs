namespace LumenSolar.WebAPI.Models.Familias
{
    public class FamiliaOutPutModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public decimal RendaMensal { get; set; }
        public int NumeroIntegrantes { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
    }
}
