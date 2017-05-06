using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class DocumentDataMap : EntityTypeConfiguration<DocumentData>
    {
        public DocumentDataMap()
        {
            // Primary Key
            this.HasKey(t => t.RowUnqRef);

            // Properties
            this.Property(t => t.RowUnqRef)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.DocNumber)
                .HasMaxLength(32);

            this.Property(t => t.DocPrefix)
                .HasMaxLength(32);

            this.Property(t => t.DocDisplayNumber)
                .HasMaxLength(32);

            this.Property(t => t.DocID)
                .HasMaxLength(16);

            this.Property(t => t.Description)
                .HasMaxLength(128);

            this.Property(t => t.ItemFullCode)
                .HasMaxLength(64);

            this.Property(t => t.ItemCode)
                .HasMaxLength(32);

            this.Property(t => t.ItemShortCode)
                .HasMaxLength(32);

            this.Property(t => t.SubInvCode)
                .HasMaxLength(16);

            this.Property(t => t.SessionUnqRef)
                .HasMaxLength(16);

            this.Property(t => t.BranchCode)
                .HasMaxLength(16);

            this.Property(t => t.ContactFullCode)
                .HasMaxLength(64);

            this.Property(t => t.ColorCode)
                .HasMaxLength(16);

            this.Property(t => t.ManualRef)
                .HasMaxLength(32);

            this.Property(t => t.BranchRef)
                .HasMaxLength(16);

            this.Property(t => t.RefDocNumber)
                .HasMaxLength(32);

            this.Property(t => t.Xref06)
                .HasMaxLength(200);

            this.Property(t => t.Xref07)
                .HasMaxLength(200);

            this.Property(t => t.Xref08)
                .HasMaxLength(200);

            this.Property(t => t.Xref09)
                .HasMaxLength(200);

            this.Property(t => t.Xref10)
                .HasMaxLength(200);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("DocumentData");
            this.Property(t => t.RowUnqRef).HasColumnName("RowUnqRef");
            this.Property(t => t.DocUnqRef).HasColumnName("DocUnqRef");
            this.Property(t => t.RowSerial).HasColumnName("RowSerial");
            this.Property(t => t.DocNumber).HasColumnName("DocNumber");
            this.Property(t => t.DocPrefix).HasColumnName("DocPrefix");
            this.Property(t => t.DocSerial).HasColumnName("DocSerial");
            this.Property(t => t.DocDisplayNumber).HasColumnName("DocDisplayNumber");
            this.Property(t => t.DocID).HasColumnName("DocID");
            this.Property(t => t.DocDate).HasColumnName("DocDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ItemFullCode).HasColumnName("ItemFullCode");
            this.Property(t => t.ItemCode).HasColumnName("ItemCode");
            this.Property(t => t.ItemShortCode).HasColumnName("ItemShortCode");
            this.Property(t => t.DocQuantity).HasColumnName("DocQuantity");
            this.Property(t => t.DocRate).HasColumnName("DocRate");
            this.Property(t => t.DocAmount).HasColumnName("DocAmount");
            this.Property(t => t.SubInvCode).HasColumnName("SubInvCode");
            this.Property(t => t.SessionUnqRef).HasColumnName("SessionUnqRef");
            this.Property(t => t.BranchCode).HasColumnName("BranchCode");
            this.Property(t => t.ContactFullCode).HasColumnName("ContactFullCode");
            this.Property(t => t.ColorCode).HasColumnName("ColorCode");
            this.Property(t => t.DiscountPer).HasColumnName("DiscountPer");
            this.Property(t => t.DiscountAmt).HasColumnName("DiscountAmt");
            this.Property(t => t.TaxAmt).HasColumnName("TaxAmt");
            this.Property(t => t.TaxPer).HasColumnName("TaxPer");
            this.Property(t => t.DueDate).HasColumnName("DueDate");
            this.Property(t => t.ManualRef).HasColumnName("ManualRef");
            this.Property(t => t.BranchRef).HasColumnName("BranchRef");
            this.Property(t => t.RefDocUnqRef).HasColumnName("RefDocUnqRef");
            this.Property(t => t.RefDocNumber).HasColumnName("RefDocNumber");
            this.Property(t => t.PaymentTermID).HasColumnName("PaymentTermID");
            this.Property(t => t.CostPrice).HasColumnName("CostPrice");
            this.Property(t => t.IsSeasonalItem).HasColumnName("IsSeasonalItem");
            this.Property(t => t.IsPosted).HasColumnName("IsPosted");
            this.Property(t => t.Xref01).HasColumnName("Xref01");
            this.Property(t => t.Xref02).HasColumnName("Xref02");
            this.Property(t => t.Xref03).HasColumnName("Xref03");
            this.Property(t => t.Xref04).HasColumnName("Xref04");
            this.Property(t => t.Xref05).HasColumnName("Xref05");
            this.Property(t => t.Xref06).HasColumnName("Xref06");
            this.Property(t => t.Xref07).HasColumnName("Xref07");
            this.Property(t => t.Xref08).HasColumnName("Xref08");
            this.Property(t => t.Xref09).HasColumnName("Xref09");
            this.Property(t => t.Xref10).HasColumnName("Xref10");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.Branch)
                .WithMany(t => t.DocumentDatas)
                .HasForeignKey(d => d.BranchCode);
            this.HasOptional(t => t.Color)
                .WithMany(t => t.DocumentDatas)
                .HasForeignKey(d => d.ColorCode);
            this.HasOptional(t => t.Contact)
                .WithMany(t => t.DocumentDatas)
                .HasForeignKey(d => d.ContactFullCode);
            this.HasOptional(t => t.DocumentNumber)
                .WithMany(t => t.DocumentDatas)
                .HasForeignKey(d => d.DocUnqRef);
            this.HasOptional(t => t.DocumentType)
                .WithMany(t => t.DocumentDatas)
                .HasForeignKey(d => d.DocID);
            this.HasOptional(t => t.Item)
                .WithMany(t => t.DocumentDatas)
                .HasForeignKey(d => d.ItemFullCode);
            this.HasOptional(t => t.PaymentTerm)
                .WithMany(t => t.DocumentDatas)
                .HasForeignKey(d => d.PaymentTermID);
            this.HasOptional(t => t.Session)
                .WithMany(t => t.DocumentDatas)
                .HasForeignKey(d => d.SessionUnqRef);
            this.HasOptional(t => t.SubInventory)
                .WithMany(t => t.DocumentDatas)
                .HasForeignKey(d => d.SubInvCode);

        }
    }
}
