using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Commands.Livro;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly LivroHandler _handler;
        private readonly ILivroRepository _repository;

        public LivroController(LivroHandler handler, ILivroRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpPost]
        public ICommandResult Inserir(LivroInserirCommand command)
        {
            var result = _handler.Execute(command);
            return result;
        }
        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var result = _repository.BuscarTodos();

            return Ok(result);
        }

        [HttpPut]
        public ICommandResult Alterar(LivroAlterarCommand command)
        {
            var result = _handler.Execute(command);

            return result;
        }

        [HttpGet("id")]
        public IActionResult BuscarPorId(int id)
        {
            var result = _repository.BuscarPorId(id);

            return Ok(result);

        }

        [HttpDelete]
        public ICommandResult Excluir(LivroExcluirCommand command)
        {
            var result = _handler.Execute(command);

            return result;
        }
    }
}
