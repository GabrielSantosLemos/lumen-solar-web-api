namespace LumenSolar.WebAPI.Models.Doadores
{
    public class Doacao
    {
        public Doacao(decimal valor, DateTime data)
        {
            Valor = valor;
            Data = data;
        }

        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public Doador Doador { get; set; }
        public int DoadorId { get; set; }
    }
}
