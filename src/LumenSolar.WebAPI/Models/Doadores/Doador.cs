using LumenSolar.WebAPI.Models.Users;

namespace LumenSolar.WebAPI.Models.Doadores
{
    public class Doador
    {
        public int Id { get; set; }
        public string Cpf { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    }
}
