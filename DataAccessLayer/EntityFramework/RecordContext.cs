using DataAccessLayer.Entities;
using System.Data.Entity;

namespace DataAccessLayer.EntityFramework
{
    class RecordContext : DbContext
    {
        public DbSet<Record> Records { get; set; }

        public RecordContext(string connectionString)
                    : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RecordConfiguration());
        }
    }
}
