using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class DocumentSizeMap : EntityTypeConfiguration<DocumentSize>
    {
        public DocumentSizeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.RowUnqRef, t.SizeCode });

            // Properties
            this.Property(t => t.RowUnqRef)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.SizeCode)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("DocumentSizes");
            this.Property(t => t.RowUnqRef).HasColumnName("RowUnqRef");
            this.Property(t => t.SizeCode).HasColumnName("SizeCode");
            this.Property(t => t.SizeQty).HasColumnName("SizeQty");

            // Relationships
            this.HasRequired(t => t.DocumentData)
                .WithMany(t => t.DocumentSizes)
                .HasForeignKey(d => d.RowUnqRef);
            this.HasRequired(t => t.Size)
                .WithMany(t => t.DocumentSizes)
                .HasForeignKey(d => d.SizeCode);

        }
    }
}
