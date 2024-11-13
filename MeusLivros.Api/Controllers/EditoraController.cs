using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Handlers;
using MeusLivros.Domain.Repositories;
using MeusLivros.Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private readonly EditoraHandler _editoraHandler;
        private readonly IEditoraRepository _editoraRepository;

        public EditoraController(
            EditoraHandler editoraHandler,
            IEditoraRepository editoraRepository)
        {
            _editoraHandler = editoraHandler;
            _editoraRepository = editoraRepository;
           
        }

        [HttpPost]
        public ICommandResult Inserir(EditoraInserirCommand command)
        {
          
            var result = _editoraHandler.Execute(command);
           
            return result;
        }

        [HttpGet]
        public IActionResult BuscarTodas()
        {
            var result = _editoraRepository.BuscarTodos();

            return Ok(result);
        }

        [HttpPut]
        public ICommandResult Alterar(EditoraAlterarCommand command)
        {
            var result = _editoraHandler.Execute(command);

            return result;
        }

        [HttpGet("id")]
        public IActionResult BuscarPorId(int id)
        {
            var result = _editoraRepository.BuscarPorId(id);    

            return Ok(result);

        }

        [HttpDelete]
        public ICommandResult Excluir(EditoraExcluirCommand command)
        {
            var result = _editoraHandler.Execute(command);

            return result;
        }
    }
}
