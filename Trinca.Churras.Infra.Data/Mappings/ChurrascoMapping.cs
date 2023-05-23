using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trinca.Churras.Domain;

namespace Trinca.Churras.Infra.Data.Mappings
{
    public class ChurrascoMapping : IEntityTypeConfiguration<Churrasco>
    {
        public void Configure(EntityTypeBuilder<Churrasco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier");

            builder.Property(o => o.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("varchar(100)");

            builder.Property(o => o.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasColumnType("datetime2");

            builder.Property(o => o.DataComemorativa)
               .HasColumnName("DataComemorativa")
               .HasColumnType("date");

            builder.Property(o => o.Descricao)
               .HasColumnName("Descricao")
               .HasColumnType("varchar(100)");

            builder.Property(o => o.ObservacaoAdicional)
               .HasColumnName("ObservacaoAdicional")
               .HasColumnType("varchar(100)");

            builder.Property(o => o.ValorSugeridoPorPessoa)
              .HasColumnName("ValorSugeridoPorPessoa")
              .HasColumnType("decimal(18,2)");

            builder.Property(o => o.ValorAdicionalBebida)
             .HasColumnName("ValorAdicionalBebida")
             .HasColumnType("decimal(18,2)");

            builder.ToTable("Churrasco");
        }
    }
}
