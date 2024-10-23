using MeusLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Repositories
{
    public interface IEditoraRepository
    {
        void Inserir (Editora editora);
        void Alterar (Editora editora);
        void Excluir (Editora editora);

        IEnumerable<Editora> BuscarTodos ();
        Editora? BuscarPorId (int id);

    }
}
