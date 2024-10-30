using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Handlers.Interfaces;
using MeusLivros.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Handlers
{

    public class EditoraHandler : IHandler<EditoraInserirCommand>
    {
        private readonly IEditoraRepository _editoraRepository;

        public EditoraHandler(IEditoraRepository editoraRepository)
        {
            _editoraRepository = editoraRepository;
        }

        public ICommandResult Execute(EditoraInserirCommand command)
        {
            //Fail Fast Validation
            command.Validar();
            if (command.IsValida)
            {
                return new ComandResult(false, "Dados incorretos", command.Notificacoes);
            }
            //cria a classe editora com os dados do command
            var editora = new Editora(command.Nome);

            //salva no banco de dados
            _editoraRepository.Inserir(editora);
            //retorna sucesso na inclusão

            return new ComandResult(true, "Editora inserir", editora);
        }
    }
}
