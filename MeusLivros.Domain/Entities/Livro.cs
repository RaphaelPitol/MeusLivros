using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Entities
{
    public class Livro : Entity 
    {
        #region Propriedades
        public string Nome { get; set; }
        public DateTime Lancamento  { get; set; } 
        public int EditoraId { get; set; }
        public Editora Editora { get; set; }

        #endregion

        #region Construtores

        public Livro(string nome, DateTime lancamento, int editora)
        {
            Nome = nome;
            Lancamento = lancamento;
            EditoraId = editora;
        }

        public Livro(int id, string nome, DateTime lancamento, int editora)
        {
            Id = id;
            Nome = nome;
            Lancamento = lancamento;
            EditoraId = editora;
        }
        #endregion

    }
}
