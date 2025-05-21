using LumenSolar.WebAPI.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace LumenSolar.WebAPI.Models.Doadores
{
    public class Doador
    {
        private Doador() { }

        public Doador(string cpf, IdentityUser user)
        {
            Cpf = cpf;
            User = user;
        }

        public int Id { get; set; }
        public string Cpf { get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; set; }
    }
}
