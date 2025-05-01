namespace ProjetoLivro.Models
{
    public class TipoUsuario
    {
        public int TipoUsuarioId { get; set; }
        public int DescricaoTipo { get; set; }

        public List<Usuario> Usuarios { get; set; } = new();

    }
}
