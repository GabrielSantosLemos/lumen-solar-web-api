using Microsoft.AspNetCore.Identity;

namespace LumenSolar.WebAPI.Models.Familias
{
    public class Familia
    {
        private Familia() { }

        public Familia(
            string nomeResponsavel,
            string cpf,
            string celular,
            decimal rendaFamiliar,
            int numeroMoradores,
            decimal gastoComEnergia,
            string situacaoVulnerabilidade,
            FamiliaEndereco endereco,
            string userId)
        {
            NomeResponsavel = nomeResponsavel;
            Cpf = cpf;
            Celular = celular;
            RendaFamiliar = rendaFamiliar;
            NumeroMoradores = numeroMoradores;
            GastoComEnergia = gastoComEnergia;
            SituacaoVulnerabilidade = situacaoVulnerabilidade;
            Endereco = endereco;
            UserId = userId;

            Status = StatusEnum.EmAnalise;
        }

        public int Id { get; set; }
        public string NomeResponsavel { get; set; }
        public string Cpf { get; set; }
        public string Celular { get; set; }
        public decimal RendaFamiliar { get; set; }
        public int NumeroMoradores { get; set; }
        public decimal GastoComEnergia { get; set; }
        public string SituacaoVulnerabilidade { get; set; }
        public StatusEnum Status { get; set; }

        public FamiliaEndereco Endereco { get; set; }
        public int EnderecoId { get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public void AtualizarStatus(StatusEnum status)
        {
            Status = status;
        }

        public void Atualizar(
            string nomeResponsavel,
            string cpf,
            string celular,
            decimal rendaFamiliar,
            int numeroMoradores,
            decimal gastoComEnergia,
            string situacaoVulnerabilidade
            )
        {
            NomeResponsavel = nomeResponsavel;
            Cpf = cpf;
            Celular = celular;
            RendaFamiliar = rendaFamiliar;
            NumeroMoradores = numeroMoradores;
            GastoComEnergia = gastoComEnergia;
            SituacaoVulnerabilidade = situacaoVulnerabilidade;
        }
    }
}
