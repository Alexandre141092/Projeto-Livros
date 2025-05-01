namespace ProjetoLivro.Models
{
    public class Assinaturas
    {
        public int AssinaturaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Status { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
