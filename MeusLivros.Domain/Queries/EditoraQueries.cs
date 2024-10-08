using MeusLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Queries
{
    public class EditoraQueries
    {
        public static Expression<Func<Editora, bool>> BuscarPorId(int  id)
        {
            // WHERE ed_id = id

            return x => x.Id == id;
        }

        public static Expression<Func<Editora, bool>> BuscarPorNome(string nome)
        {
            return x =>x.Nome.Contains(nome);
        }
    }
}
