namespace LumenSolar.WebAPI.Models.PaineisSolares
{
    public class PainelSolar
    {
        private PainelSolar() { }

        public PainelSolar(
            string marca,
            string modelo,
            decimal potencia,
            decimal tensao,
            decimal corrente,
            decimal eficiencia,
            string localizacao)
        {
            Marca = marca;
            Modelo = modelo;
            Potencia = potencia;
            Tensao = tensao;
            Corrente = corrente;
            Eficiencia = eficiencia;
            Localizacao = localizacao;
            DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Potencia { get; set; }
        public decimal Tensao { get; set; }
        public decimal Corrente { get; set; }
        public decimal Eficiencia { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataCadastro { get; set; }

        public void Atualizar(
            string marca,
            string modelo,
            decimal potencia,
            decimal tensao,
            decimal corrente,
            decimal eficiencia,
            string localizacao)
        {
            Marca = marca;
            Modelo = modelo;
            Potencia = potencia;
            Tensao = tensao;
            Corrente = corrente;
            Eficiencia = eficiencia;
            Localizacao = localizacao;
        }
    }
}
