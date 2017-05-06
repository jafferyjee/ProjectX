using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class PhotoMap : EntityTypeConfiguration<Photo>
    {
        public PhotoMap()
        {
            // Primary Key
            this.HasKey(t => t.PhotoID);

            // Properties
            this.Property(t => t.FileName)
                .HasMaxLength(50);

            this.Property(t => t.FileActualName)
                .HasMaxLength(500);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Photos");
            this.Property(t => t.PhotoID).HasColumnName("PhotoID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.FileActualName).HasColumnName("FileActualName");
            this.Property(t => t.PhotoType).HasColumnName("PhotoType");
            this.Property(t => t.FileSize).HasColumnName("FileSize");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.Company)
                .WithMany(t => t.Photos)
                .HasForeignKey(d => d.CompanyID);

        }
    }
}
