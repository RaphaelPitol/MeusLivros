using MeusLivros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeusLivros.Infra.Mappings
{
    public class EditoraMap : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            //Especificando o nome da tabela
            builder.ToTable("TbEditora");
            //Especifica qual a chave primaria da tabela
            builder.HasKey(x => x.Id);

            //especifica que o campo é auto increment
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("EdiNome") // Nome da coluna do banco de dados
                .HasColumnType("VARCHAR") // Tipo de dados da coluna 
                .HasMaxLength(100)        // Define o tamanho do campo
                .IsRequired();            // Define o campo como obrigatorio(NOTNULL)
        }
    }
}
