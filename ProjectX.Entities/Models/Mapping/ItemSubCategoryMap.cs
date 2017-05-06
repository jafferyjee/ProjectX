using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ItemSubCategoryMap : EntityTypeConfiguration<ItemSubCategory>
    {
        public ItemSubCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.SubCategoryCode);

            // Properties
            this.Property(t => t.SubCategoryCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MainCategoryCode)
                .HasMaxLength(50);

            this.Property(t => t.SubCategoryName)
                .HasMaxLength(50);

            this.Property(t => t.SubInvCode)
                .HasMaxLength(16);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ItemSubCategories");
            this.Property(t => t.SubCategoryCode).HasColumnName("SubCategoryCode");
            this.Property(t => t.MainCategoryCode).HasColumnName("MainCategoryCode");
            this.Property(t => t.SubCategoryName).HasColumnName("SubCategoryName");
            this.Property(t => t.SubInvCode).HasColumnName("SubInvCode");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.ItemMainCategory)
                .WithMany(t => t.ItemSubCategories)
                .HasForeignKey(d => d.MainCategoryCode);
            this.HasOptional(t => t.SubInventory)
                .WithMany(t => t.ItemSubCategories)
                .HasForeignKey(d => d.SubInvCode);

        }
    }
}
