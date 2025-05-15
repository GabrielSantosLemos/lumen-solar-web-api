using LumenSolar.WebAPI.Models.Users;

namespace LumenSolar.WebAPI.Models.Familias
{
    public class Familia
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public decimal RendaMensal { get; set; }
        public int NumeroIntegrantes { get; set; }

        public FamiliaEndereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    }
}
