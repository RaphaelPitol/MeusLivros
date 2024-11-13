using MeusLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MeusLivros.Infra.Mappings
{
    public class EditoraMap : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            // Especificando o nome da tabela no banco de dados
            builder.ToTable("TbEditora");

            // Especificando a chave primária
            builder.HasKey(x => x.Id);

            // Configurando o campo 'Id' como chave primária auto-incrementada
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd()
                   .UseIdentityColumn();

            // Configuração para o campo 'Nome'
            builder.Property(x => x.Nome)
                   .HasColumnName("EdiNome") // Nome da coluna no banco de dados
                   .HasColumnType("VARCHAR(100)") // Tipo e tamanho de dados da coluna
                   .IsRequired(); // Define que o campo é obrigatório

            // Configuração para a relação com 'Livro' (caso precise garantir mapeamento de relacionamento)
            builder.HasMany(x => x.Livros)
                   .WithOne(x => x.Editora)
                   .HasForeignKey(x => x.EditoraId)
                   .OnDelete(DeleteBehavior.Restrict); // Define ação ao excluir uma 'Editora'
        }
    }
}
