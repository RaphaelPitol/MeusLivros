using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Commands.Livro
{
    public class LivroExcluirCommand : Notificavel, ICommand
    {
        public LivroExcluirCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public void Validar()
        {
            if (Id == 0)
            {
                AddNotificacao("Codigo informado inválido!");
            }
        }
    }
}
