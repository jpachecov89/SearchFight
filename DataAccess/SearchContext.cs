using DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess
{
    public class SearchContext : DbContext
    {
        public SearchContext(DbContextOptions<SearchContext> options) : base(options) { }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<ProgramLanguage> ProgramLanguage { get; set; }
        public DbSet<LanguageSearch> LanguageSearch { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var realtionship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                realtionship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder
            .Entity<Engine>()
            .Property(t => t.EngineId)
            .IsRequired();

            modelBuilder
            .Entity<ProgramLanguage>()
            .Property(t => t.ProgramLanguageId)
            .IsRequired();

            modelBuilder
            .Entity<LanguageSearch>()
            .Property(t => t.LanguageSearchId)
            .IsRequired();
        }
    }
}
