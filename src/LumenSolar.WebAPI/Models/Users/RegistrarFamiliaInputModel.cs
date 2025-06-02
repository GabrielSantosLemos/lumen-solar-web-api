using LumenSolar.WebAPI.Models.Familias;

namespace LumenSolar.WebAPI.Models.Users
{
    public class RegistrarFamiliaInputModel
    {
        public FamiliaInputModel Familia { get; set; }
        public string Senha { get; set; }
    }
}
