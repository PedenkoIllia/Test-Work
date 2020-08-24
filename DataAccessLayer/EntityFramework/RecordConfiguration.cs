using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityFramework
{
    class RecordConfiguration : IEntityTypeConfiguration<Record>
    {         

        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasIndex(r => r.Id);

            builder.ToTable("tbl_Record");

            builder.Property(r => r.Code)
                    .HasColumnType("varchar(3)")
                    .HasColumnName("code");

            builder.Property(r => r.Name)
                    .HasColumnName("value");
        }
    }
}
