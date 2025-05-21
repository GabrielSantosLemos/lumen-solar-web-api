using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace LumenSolar.WebAPI.Models.Familias
{
    public class Familia
    {
        private Familia() { }

        public Familia(string cpf, decimal rendaMensal, int numeroIntegrantes, FamiliaEndereco endereco, IdentityUser user)
        {
            Cpf = cpf;
            RendaMensal = rendaMensal;
            NumeroIntegrantes = numeroIntegrantes;
            Endereco = endereco;
            User = user;
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public decimal RendaMensal { get; set; }
        public int NumeroIntegrantes { get; set; }

        public FamiliaEndereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }
    }
}
