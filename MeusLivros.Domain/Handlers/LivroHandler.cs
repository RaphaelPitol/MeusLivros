using MeusLivros.Domain.Commands;
using MeusLivros.Domain.Commands.Editora;
using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Commands.Livro;
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
    public class LivroHandler : 
        IHandler<LivroInserirCommand>,
        IHandler<LivroAlterarCommand>,
        IHandler<LivroExcluirCommand>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public ICommandResult Execute(LivroInserirCommand command)
        {
            command.Validar();
            if(!command.IsValida)
            {
                return new ComandResult(false, "Dados Incorretos", command.Notificacoes);
            }
            var livro = new Livro(command.Nome, command.DataLancamento, command.EditoraId);

            _livroRepository.Inserir(livro);

            return new ComandResult(true, "Livro Cadastrado", livro);
        }

        public ICommandResult Execute(LivroAlterarCommand command)
        { //Fail Fast Validation
            command.Validar();
            if (!command.IsValida)
            {
                return new ComandResult(false, "Dados incorretos", command.Notificacoes);
            }
            //cria a classe editora com os dados do command
            var editora = _livroRepository.BuscarPorId(command.Id);

            editora.Nome = command.Nome;

            //salva no banco de dados
            _livroRepository.Alterar(editora);
            //retorna sucesso na inclusão

            return new ComandResult(true, "Editora Alterada", editora);
        }

        public ICommandResult Execute(LivroExcluirCommand command)
        {
            command.Validar();
            if (!command.IsValida)
            {
                return new ComandResult(false, "Dados incorretos", command.Notificacoes);
            }
            //cria a classe editora com os dados do command
            var editora = _livroRepository.BuscarPorId(command.Id);

            //salva no banco de dados
            _livroRepository.Excluir(editora);
            //retorna sucesso na inclusão

            return new ComandResult(true, "Editora Excluida", editora);
        }
    }
}
