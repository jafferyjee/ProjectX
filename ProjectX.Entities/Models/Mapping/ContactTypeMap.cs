using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ContactTypeMap : EntityTypeConfiguration<ContactType>
    {
        public ContactTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ContactTypeCode);

            // Properties
            this.Property(t => t.ContactTypeCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.ContactTypeName)
                .HasMaxLength(32);

            this.Property(t => t.CodeFormat)
                .HasMaxLength(16);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("ContactTypes");
            this.Property(t => t.ContactTypeCode).HasColumnName("ContactTypeCode");
            this.Property(t => t.ContactTypeName).HasColumnName("ContactTypeName");
            this.Property(t => t.CodeFormat).HasColumnName("CodeFormat");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
