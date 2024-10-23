using MeusLivros.Domain.Commands.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Commands
{
    public class ComandResult : ICommandResult
    {
        public ComandResult(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

        public object Dados { get; set; }


    }
}
