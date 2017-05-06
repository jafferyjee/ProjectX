using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ItemMap : EntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            // Primary Key
            this.HasKey(t => t.ItemFullCode);

            // Properties
            this.Property(t => t.ItemFullCode)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.ItemCode)
                .HasMaxLength(32);

            this.Property(t => t.ItemName)
                .HasMaxLength(32);

            this.Property(t => t.ItemShortCode)
                .HasMaxLength(32);

            this.Property(t => t.SupplierCode)
                .HasMaxLength(64);

            this.Property(t => t.SubInvCode)
                .HasMaxLength(16);

            this.Property(t => t.MainCategoryCode)
                .HasMaxLength(50);

            this.Property(t => t.SubCategoryCode)
                .HasMaxLength(50);

            this.Property(t => t.RefCode)
                .HasMaxLength(32);

            this.Property(t => t.Photo)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Items");
            this.Property(t => t.ItemFullCode).HasColumnName("ItemFullCode");
            this.Property(t => t.ItemCode).HasColumnName("ItemCode");
            this.Property(t => t.ItemName).HasColumnName("ItemName");
            this.Property(t => t.ItemShortCode).HasColumnName("ItemShortCode");
            this.Property(t => t.SupplierCode).HasColumnName("SupplierCode");
            this.Property(t => t.SubInvCode).HasColumnName("SubInvCode");
            this.Property(t => t.MainCategoryCode).HasColumnName("MainCategoryCode");
            this.Property(t => t.SubCategoryCode).HasColumnName("SubCategoryCode");
            this.Property(t => t.PurchasePrice).HasColumnName("PurchasePrice");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.ArrivalDate).HasColumnName("ArrivalDate");
            this.Property(t => t.RefCode).HasColumnName("RefCode");
            this.Property(t => t.TColumn).HasColumnName("TColumn");
            this.Property(t => t.TColumnByAmt).HasColumnName("TColumnByAmt");
            this.Property(t => t.IsGiftItem).HasColumnName("IsGiftItem");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.Contact)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.SupplierCode);
            this.HasOptional(t => t.ItemMainCategory)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.MainCategoryCode);
            this.HasOptional(t => t.ItemSubCategory)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.SubCategoryCode);
            this.HasOptional(t => t.SubInventory)
                .WithMany(t => t.Items)
                .HasForeignKey(d => d.SubInvCode);

        }
    }
}
