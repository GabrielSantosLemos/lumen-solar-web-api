using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LumenSolar.WebAPI.Models.Doadores
{

    public class DoadorInputModel
    {
       
        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

    }
}
