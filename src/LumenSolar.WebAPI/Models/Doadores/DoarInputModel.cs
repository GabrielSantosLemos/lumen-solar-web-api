using System.ComponentModel.DataAnnotations;

namespace LumenSolar.WebAPI.Models.Doadores
{
    public class DoarInputModel
    {
        [Required]
        public decimal Valor { get; set; }
    }
}
