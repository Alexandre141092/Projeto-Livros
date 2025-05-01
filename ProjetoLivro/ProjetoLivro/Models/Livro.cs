namespace ProjetoLivro.Models
{
    public class Livro
    {
        public int LivroId { get; set; }
        public int Titulo { get; set; }
        public int Autor { get; set; }
        public int? Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categorias { get; set; }
        public List<Livro> livros { get; set; } = new();

    }
}
