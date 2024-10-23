using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Commands.Editora
{
    public class EditoraInserirCommand : Notificavel, ICommand
    {

        public EditoraInserirCommand(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                AddNoticacao("O Nome da editora é obrigátorio!");
            }
        }
    }
}
