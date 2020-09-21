namespace ConsulAPI.Models.DTO
{
    public class ClienteCreateDto
    {
        public int Id { get; set; }
        public string NomeRazaoSocial { get; set; }
        public string CpfCnpj { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public int Classificacao { get; set; }
        public string Telefone { get; set; }
    }
}
