using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class RangeMap : EntityTypeConfiguration<Range>
    {
        public RangeMap()
        {
            // Primary Key
            this.HasKey(t => t.RangeCode);

            // Properties
            this.Property(t => t.RangeCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.RangeName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Ranges");
            this.Property(t => t.RangeCode).HasColumnName("RangeCode");
            this.Property(t => t.RangeName).HasColumnName("RangeName");
        }
    }
}
