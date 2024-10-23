using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Domain.Validations
{
    public abstract class Notificavel
    {
        private readonly List<string> _notificacoes;

        public Notificavel()
        {
            _notificacoes = new List<string>();
        }

        public void AddNoticacao(string notificacoes)
        {
            _notificacoes.Add(notificacoes);
        }

        //è uma lista de string porem somente de leitura IReadOnlyCollection
        public IReadOnlyCollection<string> Notificacoes => _notificacoes;


        public bool isInvalida => _notificacoes.Any();

        public bool isValida => !isInvalida;
    }
}
