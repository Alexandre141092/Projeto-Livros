using ProjetoLivro.Models;

namespace ProjetoLivro.Interfaces
{
    public interface ILivroRepository
    {
        Task<List<Livro>> ListarTodosAsync();

        
       
    }
        
}
