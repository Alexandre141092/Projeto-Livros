using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivro.Interface;
using ProjetoLivro.Models;

namespace ProjetoLivro.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaControllers : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaControllers(ICategoriaRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult ListarTodos()
        {
            var categorias = _repository.ListarTodos();

            return Ok(categorias);
        }
        [HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            _repository.Cadastrar(categoria);

            return Created();
        }
    }
}
