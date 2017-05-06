using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ItemMainCategoryMap : EntityTypeConfiguration<ItemMainCategory>
    {
        public ItemMainCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.MainCategoryCode);

            // Properties
            this.Property(t => t.MainCategoryCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MainCategoryName)
                .HasMaxLength(50);

            this.Property(t => t.SubInvCode)
                .HasMaxLength(16);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ItemMainCategories");
            this.Property(t => t.MainCategoryCode).HasColumnName("MainCategoryCode");
            this.Property(t => t.MainCategoryName).HasColumnName("MainCategoryName");
            this.Property(t => t.SubInvCode).HasColumnName("SubInvCode");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.SubInventory)
                .WithMany(t => t.ItemMainCategories)
                .HasForeignKey(d => d.SubInvCode);

        }
    }
}
