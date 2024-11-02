using MeusLivros.Domain.Commands;
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
    public class LivroHandler : IHandler<LivroInserirCommand>
    {
        private readonly ILivroRepository _livroRepository;

        public LivroHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public ICommandResult Execute(LivroInserirCommand command)
        {
            command.Validar();
            if(command.IsValida)
            {
                return new ComandResult(false, "Dados Incorretos", command.Notificacoes);
            }
            var livro = new Livro(command.Nome, command.DataLancamento, command.EditoraId);

            _livroRepository.Inserir(livro);

            return new ComandResult(true, "Livro Cadastrado", livro);
        }
    }
}
