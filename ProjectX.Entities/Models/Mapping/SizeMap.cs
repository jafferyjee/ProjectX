using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class SizeMap : EntityTypeConfiguration<Size>
    {
        public SizeMap()
        {
            // Primary Key
            this.HasKey(t => t.SizeCode);

            // Properties
            this.Property(t => t.SizeCode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SizeName)
                .HasMaxLength(32);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Sizes");
            this.Property(t => t.SizeCode).HasColumnName("SizeCode");
            this.Property(t => t.SizeName).HasColumnName("SizeName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasMany(t => t.SubInventories)
                .WithMany(t => t.Sizes)
                .Map(m =>
                    {
                        m.ToTable("SubInventorySizes");
                        m.MapLeftKey("SizeCode");
                        m.MapRightKey("SubInvCode");
                    });


        }
    }
}
