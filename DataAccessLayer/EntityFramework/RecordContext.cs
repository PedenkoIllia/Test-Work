using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class RecordContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        public RecordContext(DbContextOptions<RecordContext> options)
                    : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecordConfiguration());
        }
    }
}
