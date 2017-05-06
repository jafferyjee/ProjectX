using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class DocumentTypeMap : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.DocID);

            // Properties
            this.Property(t => t.DocID)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.DocName)
                .HasMaxLength(32);

            this.Property(t => t.StockEffect)
                .HasMaxLength(16);

            // Table & Column Mappings
            this.ToTable("DocumentTypes");
            this.Property(t => t.DocID).HasColumnName("DocID");
            this.Property(t => t.DocName).HasColumnName("DocName");
            this.Property(t => t.StockEffect).HasColumnName("StockEffect");
            this.Property(t => t.DisplayOrder).HasColumnName("DisplayOrder");
            this.Property(t => t.IsSessionBased).HasColumnName("IsSessionBased");
        }
    }
}
