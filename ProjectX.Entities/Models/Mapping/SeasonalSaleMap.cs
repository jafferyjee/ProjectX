using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class SeasonalSaleMap : EntityTypeConfiguration<SeasonalSale>
    {
        public SeasonalSaleMap()
        {
            // Primary Key
            this.HasKey(t => t.SaleID);

            // Properties
            this.Property(t => t.SaleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.SaleDescription)
                .HasMaxLength(256);

            this.Property(t => t.SaleBranchCodes)
                .HasMaxLength(256);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SeasonalSale");
            this.Property(t => t.SaleID).HasColumnName("SaleID");
            this.Property(t => t.SaleDescription).HasColumnName("SaleDescription");
            this.Property(t => t.SaleStartDate).HasColumnName("SaleStartDate");
            this.Property(t => t.SaleEndDate).HasColumnName("SaleEndDate");
            this.Property(t => t.SaleBranchCodes).HasColumnName("SaleBranchCodes");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
