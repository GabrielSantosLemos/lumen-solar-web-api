using System.ComponentModel.DataAnnotations;

namespace LumenSolar.WebAPI.Models.PaineisSolares
{
    public class PainelSolarInputModel
    {
        [Required(ErrorMessage = "A marca é obrigatória.")]
        [StringLength(100, ErrorMessage = "A marca deve ter no máximo 100 caracteres.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O modelo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O modelo deve ter no máximo 100 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A potência é obrigatória.")]
        [Range(0.01, 10000, ErrorMessage = "A potência deve estar entre 0.01 e 10000 Watts.")]
        public decimal Potencia { get; set; }

        [Required(ErrorMessage = "A tensão é obrigatória.")]
        [Range(0.01, 1000, ErrorMessage = "A tensão deve estar entre 0.01 e 1000 Volts.")]
        public decimal Tensao { get; set; }

        [Required(ErrorMessage = "A corrente é obrigatória.")]
        [Range(0.01, 1000, ErrorMessage = "A corrente deve estar entre 0.01 e 1000 Amperes.")]
        public decimal Corrente { get; set; }

        [Required(ErrorMessage = "A eficiência é obrigatória.")]
        [Range(0.01, 100, ErrorMessage = "A eficiência deve estar entre 0.01 e 100%.")]
        public decimal Eficiencia { get; set; }

        [Required(ErrorMessage = "A localização é obrigatória.")]
        [StringLength(200, ErrorMessage = "A localização deve ter no máximo 200 caracteres.")]
        public string Localizacao { get; set; }
    }
}
