namespace LumenSolar.WebAPI.Models.Users
{
    public class RegistrarFamiliaInputModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public decimal RendaMensal { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
    }
}
