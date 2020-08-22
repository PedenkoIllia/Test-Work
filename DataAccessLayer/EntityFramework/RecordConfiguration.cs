using DataAccessLayer.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessLayer.EntityFramework
{
    class RecordConfiguration : EntityTypeConfiguration<Record>
    {
        public RecordConfiguration() {
            ToTable("Records").HasKey(r => r.Id);
            Property(r => r.Code)
                .HasMaxLength(3)
                .HasColumnType("varchart")
                .HasColumnName("code");

            Property(r => r.Name).
                HasColumnType("varchart").
                HasColumnName("value");
        }
    }
}
