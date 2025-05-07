using Microsoft.EntityFrameworkCore;
using ProjetoLivro.Context;
using ProjetoLivro.Interface;
using ProjetoLivro.Models;

namespace ProjetoLivro.Repository
{
    //herdar e implementar
    //injetar o contexto
    public class CategoriaRepository : ICategoriaRepository
    {
        private LivrosContext _context;

        public CategoriaRepository(LivrosContext context)
        {
            _context = context;
        }

        public Categoria? Atualizar(int id, Categoria categoria)
        {
           //1 - procuro quem atualaizar
           var categoriaEncontrada = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            //2- se nao acho, retorno nulo
            if (categoriaEncontrada == null) return null;
            //3- se acho eu ataualizo as informacoes
            categoriaEncontrada.NomeCategoria = categoria.NomeCategoria;

            return categoriaEncontrada;
        }

        public void Cadastrar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);

            _context.SaveChanges();
        }

        public Categoria? Deletar(int id)
        {
            //1- procuro quem eu quero apagar
            var categoria = _context.Categorias.Find(id);
            //2- se nao achei, retorno nulo
            if (categoria == null) return null;
            //3- se achei apago
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public List<Categoria> ListarTodos()
        {
           return _context.Categorias.ToList();
        }

        public async Task<List<Categoria>> ListarTodosAsync()
        {
           return await _context.Categorias.ToListAsync();
        }
    }


}
