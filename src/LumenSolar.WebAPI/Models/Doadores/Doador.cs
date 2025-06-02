using Microsoft.AspNetCore.Identity;

namespace LumenSolar.WebAPI.Models.Doadores
{
    public class Doador
    {
        private Doador() { }

        public Doador(string nomeCompleto, string celular, string cpf, string userId)
        {
            NomeCompleto = nomeCompleto;
            Celular = celular;
            Cpf = cpf;
            UserId = userId;

            Tipo = DoadorTipoEnum.Fisica;
            NomeEmpresa = "";
            Cnpj = "";
        }

        public Doador(string nomeCompleto, string celular, string nomeEmpresa, string cnpj, string userId)
        {
            NomeCompleto = nomeCompleto;
            Celular = celular;
            NomeEmpresa = nomeEmpresa;
            Cnpj = cnpj;
            UserId = userId;

            Tipo = DoadorTipoEnum.Jurifica;
            Cpf = "";
        }

        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Celular { get; set; }
        public DoadorTipoEnum Tipo { get; set; }
        public string Cpf { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public List<Doacao> Doacoes { get; set; }

        public void Atualizar(string nomeCompleto, string celular, string cpf)
        {
            NomeCompleto = nomeCompleto;
            Celular = celular;
            Cpf = cpf;

        }

        public void Atualizar(string nomeCompleto, string celular, string nomeEmpresa, string cnpj)
        {
            NomeCompleto = nomeCompleto;
            Celular = celular;
            NomeEmpresa = nomeEmpresa;
            Cnpj = cnpj;
        }
    }
}
