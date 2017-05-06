using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class BranchMap : EntityTypeConfiguration<Branch>
    {
        public BranchMap()
        {
            // Primary Key
            this.HasKey(t => t.BranchCode);

            // Properties
            this.Property(t => t.BranchCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.BranchName)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.BranchAddress)
                .HasMaxLength(256);

            this.Property(t => t.Phone)
                .HasMaxLength(64);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Branches");
            this.Property(t => t.BranchCode).HasColumnName("BranchCode");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.BranchName).HasColumnName("BranchName");
            this.Property(t => t.BranchAddress).HasColumnName("BranchAddress");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.IsHeadOffice).HasColumnName("IsHeadOffice");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Company)
                .WithMany(t => t.Branches)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
