namespace LumenSolar.WebAPI.Models.Familias
{
    public class FamiliaEndereco
    {
        private FamiliaEndereco() { }

        public FamiliaEndereco(string cep, string rua, int numero, string bairro, string cidade, string uf)
        {
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }

        public int Id { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public void Atualizar(string cep, string rua, int numero, string bairro, string cidade, string uf)
        {
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }
    }
}
