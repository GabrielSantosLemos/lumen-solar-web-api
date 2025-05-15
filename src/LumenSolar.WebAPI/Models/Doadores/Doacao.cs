namespace LumenSolar.WebAPI.Models.Doadores
{
    public class Doacao
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }

        public Doador Doador { get; set; }
        public int DoadorId { get; set; }
    }
}
