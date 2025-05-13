namespace LumenSolar.WebAPI.Models.Doadores
{
    public class DoadoresInputModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public decimal Cpf { get; set; }
        public decimal ValorDoacao { get; set; }

    }
}
