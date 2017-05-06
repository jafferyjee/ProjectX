using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class SubInventoryMap : EntityTypeConfiguration<SubInventory>
    {
        public SubInventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.SubInvCode);

            // Properties
            this.Property(t => t.SubInvCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.SubInvName)
                .HasMaxLength(32);

            this.Property(t => t.CodeFormat)
                .HasMaxLength(16);

            this.Property(t => t.ShortName)
                .HasMaxLength(8);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SubInventory");
            this.Property(t => t.SubInvCode).HasColumnName("SubInvCode");
            this.Property(t => t.SubInvName).HasColumnName("SubInvName");
            this.Property(t => t.CodeFormat).HasColumnName("CodeFormat");
            this.Property(t => t.ShortName).HasColumnName("ShortName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
