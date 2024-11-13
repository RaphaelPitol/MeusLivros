using MeusLivros.Domain.Entities;
using MeusLivros.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Infra.Contexts
{
    public class DataContext : DbContext
    {
        //public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }
        
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Livro> Livros { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EditoraMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
        }

    }
}
