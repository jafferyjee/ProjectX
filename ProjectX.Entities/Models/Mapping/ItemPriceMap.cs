using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ItemPriceMap : EntityTypeConfiguration<ItemPrice>
    {
        public ItemPriceMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ItemFullCode, t.SizeCode, t.RangeCode });

            // Properties
            this.Property(t => t.ItemFullCode)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.SizeCode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RangeCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ItemPrices");
            this.Property(t => t.ItemFullCode).HasColumnName("ItemFullCode");
            this.Property(t => t.SizeCode).HasColumnName("SizeCode");
            this.Property(t => t.RangeCode).HasColumnName("RangeCode");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.PurchasePrice).HasColumnName("PurchasePrice");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Item)
                .WithMany(t => t.ItemPrices)
                .HasForeignKey(d => d.ItemFullCode);
            this.HasRequired(t => t.Range)
                .WithMany(t => t.ItemPrices)
                .HasForeignKey(d => d.RangeCode);
            this.HasRequired(t => t.Size)
                .WithMany(t => t.ItemPrices)
                .HasForeignKey(d => d.SizeCode);

        }
    }
}
