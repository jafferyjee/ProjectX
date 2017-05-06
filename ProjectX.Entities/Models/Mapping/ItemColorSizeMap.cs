using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ItemColorSizeMap : EntityTypeConfiguration<ItemColorSize>
    {
        public ItemColorSizeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ItemFullCode, t.ColorCode, t.SizeCode });

            // Properties
            this.Property(t => t.ItemFullCode)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.ColorCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.SizeCode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ItemColorSize");
            this.Property(t => t.ItemFullCode).HasColumnName("ItemFullCode");
            this.Property(t => t.ColorCode).HasColumnName("ColorCode");
            this.Property(t => t.SizeCode).HasColumnName("SizeCode");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Color)
                .WithMany(t => t.ItemColorSizes)
                .HasForeignKey(d => d.ColorCode);
            this.HasRequired(t => t.Item)
                .WithMany(t => t.ItemColorSizes)
                .HasForeignKey(d => d.ItemFullCode);
            this.HasRequired(t => t.Size)
                .WithMany(t => t.ItemColorSizes)
                .HasForeignKey(d => d.SizeCode);

        }
    }
}
