
using ProjetoLivro.Models;

namespace ProjetoLivro.Interface
{
    public interface ICategoriaRepository 
    {
        //Assincrono - Task(tarefa)
        Task<List<Categoria>> ListarTodosAsync();
        //sincrono
        List<Categoria> ListarTodos();

        void Cadastrar(Categoria categoria);
        Categoria? Atualizar(int id, Categoria categoria);
        Categoria? Deletar(int id);

    }
}
