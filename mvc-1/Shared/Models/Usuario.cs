namespace Shared.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataExpiracaoSenha { get; set; }
        public DateTime? DataBloqueio { get; set; }
    }
}
