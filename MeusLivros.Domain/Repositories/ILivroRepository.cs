using MeusLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Repositories
{
    public interface ILivroRepository
    {
        void Alterar (Livro livro);
        void Excluir (Livro livro);
        void Inserir (Livro livro);

        IEnumerable<Livro> BuscarTodos();
        Livro? BuscarPorId (int id);
    }
}
