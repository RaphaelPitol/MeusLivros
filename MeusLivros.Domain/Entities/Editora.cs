namespace MeusLivros.Domain.Entities
{
    public class Editora : Entity
    {
        #region Propriedades
        public string Nome { get; set; }

        public IList<Livro> Livros { get; set; }
        #endregion

        #region Construtor
        public Editora(string Nome) 
        {
            this.Nome = Nome;
            Livros = new List<Livro>();
        }

        public Editora(int id, string nome)
        {
            Id = id;
            Nome = Nome;
            Livros = new List<Livro>();
        }
        #endregion
    }
}
