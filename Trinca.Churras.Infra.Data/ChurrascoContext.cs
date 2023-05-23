using Microsoft.EntityFrameworkCore;
using Trinca.Churras.Domain;

namespace Trinca.Churras.Infra.Data
{
    public class ChurrascoContext : DbContext
    {
        public ChurrascoContext(DbContextOptions<ChurrascoContext> options) : base(options)
        {
        
        }

        protected ChurrascoContext() { }

        public DbSet<Churrasco> Churrasco { get; set; }
        public DbSet<ChurrascoParticipante> ChurrascoParticipante { get; set; }
        public DbSet<Participante> Participante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseInMemoryDatabase("TrincaChurrasco");
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ChurrascoContext).Assembly);
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") is not null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                    entry.Property("CreatedBy").CurrentValue = "test user";
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.Now;
                    entry.Property("UpdatedBy").CurrentValue = "test user";
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
