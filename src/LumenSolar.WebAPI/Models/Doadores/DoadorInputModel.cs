using System.ComponentModel.DataAnnotations;

namespace LumenSolar.WebAPI.Models.Doadores
{
    public class DoadorInputModel
    {
        [Required(ErrorMessage = "Obrigatório.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Obrigatório.")]
        public DoadorTipoEnum Tipo { get; set; }

        public string Cpf { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
    }
}
