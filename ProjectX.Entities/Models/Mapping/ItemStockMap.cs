using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ItemStockMap : EntityTypeConfiguration<ItemStock>
    {
        public ItemStockMap()
        {
            // Primary Key
            this.HasKey(t => new { t.RowUnqRef, t.ItemFullCode, t.ColorCode, t.SizeCode });

            // Properties
            this.Property(t => t.RowUnqRef)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.ItemFullCode)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.ColorCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.SizeCode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BranchCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.SubInvCode)
                .HasMaxLength(16);

            this.Property(t => t.ItemCode)
                .HasMaxLength(32);

            this.Property(t => t.ItemShortCode)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ItemStock");
            this.Property(t => t.RowUnqRef).HasColumnName("RowUnqRef");
            this.Property(t => t.ItemFullCode).HasColumnName("ItemFullCode");
            this.Property(t => t.ColorCode).HasColumnName("ColorCode");
            this.Property(t => t.SizeCode).HasColumnName("SizeCode");
            this.Property(t => t.BranchCode).HasColumnName("BranchCode");
            this.Property(t => t.SubInvCode).HasColumnName("SubInvCode");
            this.Property(t => t.QtyOnHand).HasColumnName("QtyOnHand");
            this.Property(t => t.ItemCode).HasColumnName("ItemCode");
            this.Property(t => t.ItemShortCode).HasColumnName("ItemShortCode");

            // Relationships
            this.HasRequired(t => t.Branch)
                .WithMany(t => t.ItemStocks)
                .HasForeignKey(d => d.BranchCode);
            this.HasRequired(t => t.Color)
                .WithMany(t => t.ItemStocks)
                .HasForeignKey(d => d.ColorCode);
            this.HasRequired(t => t.Item)
                .WithMany(t => t.ItemStocks)
                .HasForeignKey(d => d.ItemFullCode);
            this.HasRequired(t => t.Size)
                .WithMany(t => t.ItemStocks)
                .HasForeignKey(d => d.SizeCode);
            this.HasOptional(t => t.SubInventory)
                .WithMany(t => t.ItemStocks)
                .HasForeignKey(d => d.SubInvCode);

        }
    }
}
