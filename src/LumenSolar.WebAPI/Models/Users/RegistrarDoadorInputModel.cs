using LumenSolar.WebAPI.Models.Doadores;

namespace LumenSolar.WebAPI.Models.Users
{
    public class RegistrarDoadorInputModel
    {
        public DoadorInputModel Doador { get; set; }
        public string Senha { get; set; }
    }
}
