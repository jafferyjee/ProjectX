using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class DocumentNumberMap : EntityTypeConfiguration<DocumentNumber>
    {
        public DocumentNumberMap()
        {
            // Primary Key
            this.HasKey(t => t.DocUnqRef);

            // Properties
            this.Property(t => t.DocNumber)
                .HasMaxLength(32);

            this.Property(t => t.DocPrefix)
                .HasMaxLength(32);

            this.Property(t => t.DocID)
                .HasMaxLength(16);

            this.Property(t => t.SubInvCode)
                .HasMaxLength(16);

            this.Property(t => t.SessionUnqRef)
                .HasMaxLength(16);

            this.Property(t => t.BranchCode)
                .HasMaxLength(16);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("DocumentNumbers");
            this.Property(t => t.DocUnqRef).HasColumnName("DocUnqRef");
            this.Property(t => t.DocNumber).HasColumnName("DocNumber");
            this.Property(t => t.DocPrefix).HasColumnName("DocPrefix");
            this.Property(t => t.DocSerial).HasColumnName("DocSerial");
            this.Property(t => t.DocID).HasColumnName("DocID");
            this.Property(t => t.DocDate).HasColumnName("DocDate");
            this.Property(t => t.SubInvCode).HasColumnName("SubInvCode");
            this.Property(t => t.SessionUnqRef).HasColumnName("SessionUnqRef");
            this.Property(t => t.BranchCode).HasColumnName("BranchCode");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.Branch)
                .WithMany(t => t.DocumentNumbers)
                .HasForeignKey(d => d.BranchCode);
            this.HasOptional(t => t.DocumentType)
                .WithMany(t => t.DocumentNumbers)
                .HasForeignKey(d => d.DocID);
            this.HasOptional(t => t.Session)
                .WithMany(t => t.DocumentNumbers)
                .HasForeignKey(d => d.SessionUnqRef);
            this.HasOptional(t => t.SubInventory)
                .WithMany(t => t.DocumentNumbers)
                .HasForeignKey(d => d.SubInvCode);

        }
    }
}
