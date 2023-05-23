using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trinca.Churras.Domain;

namespace Trinca.Churras.Infra.Data.Mappings
{
    public class ParticipanteMapping : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> builder)
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

            builder.Property(o => o.Nome)
               .HasColumnName("Nome")
               .HasColumnType("varchar(250)");
          
            builder.ToTable("Participante");
        }
    }
}
