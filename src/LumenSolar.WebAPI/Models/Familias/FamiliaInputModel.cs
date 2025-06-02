using System.ComponentModel.DataAnnotations;

namespace LumenSolar.WebAPI.Models.Familias
{
    public class FamiliaInputModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do responsável é obrigatório.")]
        [StringLength(100)]
        public string NomeResponsavel { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone informado não é válido.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "A renda familiar é obrigatória.")]
        [Range(0, double.MaxValue, ErrorMessage = "A renda familiar deve ser um valor positivo.")]
        public decimal RendaFamiliar { get; set; }

        [Required(ErrorMessage = "O número de moradores é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número de moradores deve ser pelo menos 1.")]
        public int NumeroMoradores { get; set; }

        [Required(ErrorMessage = "O gasto com energia é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O gasto com energia deve ser um valor positivo.")]
        public decimal GastoComEnergia { get; set; }

        [Required(ErrorMessage = "A situação de vulnerabilidade é obrigatória.")]
        [StringLength(500)]
        public string SituacaoVulnerabilidade { get; set; }
    }
}
