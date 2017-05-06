using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class SeasonalSaleDetailMap : EntityTypeConfiguration<SeasonalSaleDetail>
    {
        public SeasonalSaleDetailMap()
        {
            // Primary Key
            this.HasKey(t => new { t.SaleID, t.RowSerial });

            // Properties
            this.Property(t => t.SaleID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RowSerial)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ItemFullCode)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.SubInvCode)
                .HasMaxLength(16);

            this.Property(t => t.RangeCode)
                .HasMaxLength(16);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("SeasonalSaleDetails");
            this.Property(t => t.SaleID).HasColumnName("SaleID");
            this.Property(t => t.RowSerial).HasColumnName("RowSerial");
            this.Property(t => t.ItemFullCode).HasColumnName("ItemFullCode");
            this.Property(t => t.SubInvCode).HasColumnName("SubInvCode");
            this.Property(t => t.RangeCode).HasColumnName("RangeCode");
            this.Property(t => t.SalePrice).HasColumnName("SalePrice");
            this.Property(t => t.DiscountPrice).HasColumnName("DiscountPrice");
            this.Property(t => t.DiscountPer).HasColumnName("DiscountPer");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasRequired(t => t.Item)
                .WithMany(t => t.SeasonalSaleDetails)
                .HasForeignKey(d => d.ItemFullCode);
            this.HasOptional(t => t.Range)
                .WithMany(t => t.SeasonalSaleDetails)
                .HasForeignKey(d => d.RangeCode);
            this.HasRequired(t => t.SeasonalSale)
                .WithMany(t => t.SeasonalSaleDetails)
                .HasForeignKey(d => d.SaleID);
            this.HasOptional(t => t.SubInventory)
                .WithMany(t => t.SeasonalSaleDetails)
                .HasForeignKey(d => d.SubInvCode);

        }
    }
}
