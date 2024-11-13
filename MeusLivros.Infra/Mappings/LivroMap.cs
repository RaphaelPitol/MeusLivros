using MeusLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeusLivros.Infra.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnName("EdiNome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Lancamento)
                .IsRequired();

            builder.Property(x => x.EditoraId)
                .IsRequired();

            builder.HasOne(x => x.Editora)          // Relacionamento entre Livro e Editora
                 .WithMany(e => e.Livros)         // Editora pode ter muitos Livros
                 .HasForeignKey(x => x.EditoraId) // Propriedade de chave estrangeira
                 .OnDelete(DeleteBehavior.Restrict); // Escolha o comportamento de exclusão, se necessário
        }
    }
}
