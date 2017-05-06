using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class SubInventorySizeRangeMap : EntityTypeConfiguration<SubInventorySizeRange>
    {
        public SubInventorySizeRangeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SubInvCode, t.RangeCode, t.SizeCode });

            // Properties
            this.Property(t => t.SubInvCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.RangeCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.SizeCode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SubInventorySizeRanges");
            this.Property(t => t.SubInvCode).HasColumnName("SubInvCode");
            this.Property(t => t.RangeCode).HasColumnName("RangeCode");
            this.Property(t => t.SizeCode).HasColumnName("SizeCode");

            // Relationships
            this.HasRequired(t => t.Range)
                .WithMany(t => t.SubInventorySizeRanges)
                .HasForeignKey(d => d.RangeCode);
            this.HasRequired(t => t.Size)
                .WithMany(t => t.SubInventorySizeRanges)
                .HasForeignKey(d => d.SizeCode);
            this.HasRequired(t => t.SubInventory)
                .WithMany(t => t.SubInventorySizeRanges)
                .HasForeignKey(d => d.SubInvCode);

        }
    }
}
