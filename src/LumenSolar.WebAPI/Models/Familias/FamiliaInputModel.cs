namespace LumenSolar.WebAPI.Models.Familias
{
    public class FamiliaInputModel
    {

        //Info pessoais
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public decimal RendaMensal { get; set; }
        public int NumeroIntegrantes { get; set; }


        //Endereço
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairra { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}
