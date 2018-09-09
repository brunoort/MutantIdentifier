using Microsoft.EntityFrameworkCore;
using MutantIdentifier.Models;

namespace MutantIdentifier.ContextDatabase
{
    public class MutantContext : DbContext
    {
        #region Constructors
        public MutantContext() : base() { }
        public MutantContext(DbContextOptions<MutantContext> options) : base(options) { }
        #endregion

        #region Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        #endregion

        #region Entities
        public DbSet<StatsModel> Stats { get; set; }        
        #endregion
    }
}
