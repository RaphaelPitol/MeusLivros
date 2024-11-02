using MeusLivros.Domain.Commands.Interfaces;
using MeusLivros.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Commands.Livro
{
    public class LivroInserirCommand : Notificavel, ICommand
    {
        public LivroInserirCommand(string nome, DateTime dataLancamento, int editoraId)
        {
            Nome = nome;
            DataLancamento = dataLancamento;
            EditoraId = editoraId;
        }

        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public int EditoraId { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nome.Trim()))
            {
                AddNotificacao("O Nome do Livro é obrigátorio!");
            }
            if (EditoraId == 0)
            {
                AddNotificacao("Insira a Editora!");
            }
        }
    }
}