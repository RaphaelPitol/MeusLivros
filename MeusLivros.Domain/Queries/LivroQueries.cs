using MeusLivros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Queries
{
    internal class LivroQueries
    {
        public static Expression<Func<Livro, bool>> BuscarPorId(int id)
        {
            
            return x => x.Id == id;
        }

        public static Expression<Func<Livro, bool>> BuscarPorNome(string nome)
        {
            return x => x.Nome.Contains(nome);
        }
}
}
