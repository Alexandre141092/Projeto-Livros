namespace ProjetoLivro.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        public int NomeCategoria { get; set; }

        public List<Livro> Livros { get; set; } = new();
    }
}
