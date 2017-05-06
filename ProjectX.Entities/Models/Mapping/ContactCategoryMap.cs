using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ContactCategoryMap : EntityTypeConfiguration<ContactCategory>
    {
        public ContactCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ContactCategoryCode);

            // Properties
            this.Property(t => t.ContactCategoryCode)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ContactCategoryName)
                .HasMaxLength(50);

            this.Property(t => t.ContactTypeCode)
                .HasMaxLength(16);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ContactCategories");
            this.Property(t => t.ContactCategoryCode).HasColumnName("ContactCategoryCode");
            this.Property(t => t.ContactCategoryName).HasColumnName("ContactCategoryName");
            this.Property(t => t.ContactTypeCode).HasColumnName("ContactTypeCode");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.ContactType)
                .WithMany(t => t.ContactCategories)
                .HasForeignKey(d => d.ContactTypeCode);

        }
    }
}
