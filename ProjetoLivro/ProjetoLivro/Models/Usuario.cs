namespace ProjetoLivro.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int NomeCompleto { get; set; }
        public int Email { get; set; }
        public int Senha { get; set; }
        public int Telefone { get; set; }
        public DateTime DataCadstro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int TipoUsuarioId { get; set; }
        public TipoUsuario? TipoUsuario { get; set; }

    }
}
