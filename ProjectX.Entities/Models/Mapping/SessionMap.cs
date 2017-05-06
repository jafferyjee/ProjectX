using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class SessionMap : EntityTypeConfiguration<Session>
    {
        public SessionMap()
        {
            // Primary Key
            this.HasKey(t => t.SessionUnqRef);

            // Properties
            this.Property(t => t.SessionUnqRef)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.BranchCode)
                .HasMaxLength(16);

            this.Property(t => t.Description)
                .HasMaxLength(512);

            this.Property(t => t.BankName1)
                .HasMaxLength(24);

            this.Property(t => t.BankName2)
                .HasMaxLength(24);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Sessions");
            this.Property(t => t.SessionUnqRef).HasColumnName("SessionUnqRef");
            this.Property(t => t.IsClosed).HasColumnName("IsClosed");
            this.Property(t => t.BranchCode).HasColumnName("BranchCode");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.OpeningBal).HasColumnName("OpeningBal");
            this.Property(t => t.Expense).HasColumnName("Expense");
            this.Property(t => t.BankDeposit1).HasColumnName("BankDeposit1");
            this.Property(t => t.SalesInvoice).HasColumnName("SalesInvoice");
            this.Property(t => t.ReplacementInvoice).HasColumnName("ReplacementInvoice");
            this.Property(t => t.OrderBooking).HasColumnName("OrderBooking");
            this.Property(t => t.CreditVoucher).HasColumnName("CreditVoucher");
            this.Property(t => t.GiftVoucher).HasColumnName("GiftVoucher");
            this.Property(t => t.PersonalCrRetrieved).HasColumnName("PersonalCrRetrieved");
            this.Property(t => t.Refund).HasColumnName("Refund");
            this.Property(t => t.CreditCard).HasColumnName("CreditCard");
            this.Property(t => t.SalesReturn).HasColumnName("SalesReturn");
            this.Property(t => t.ReplacementReturn).HasColumnName("ReplacementReturn");
            this.Property(t => t.CancelledOrder).HasColumnName("CancelledOrder");
            this.Property(t => t.CreditVoucherRedeemed).HasColumnName("CreditVoucherRedeemed");
            this.Property(t => t.GiftVoucherRedeemed).HasColumnName("GiftVoucherRedeemed");
            this.Property(t => t.PersonalCrIssued).HasColumnName("PersonalCrIssued");
            this.Property(t => t.Tax).HasColumnName("Tax");
            this.Property(t => t.Discount).HasColumnName("Discount");
            this.Property(t => t.ManualDiscount).HasColumnName("ManualDiscount");
            this.Property(t => t.CashToHO).HasColumnName("CashToHO");
            this.Property(t => t.BankDeposit2).HasColumnName("BankDeposit2");
            this.Property(t => t.CashInHand).HasColumnName("CashInHand");
            this.Property(t => t.CashFromHO).HasColumnName("CashFromHO");
            this.Property(t => t.ExtraSale).HasColumnName("ExtraSale");
            this.Property(t => t.Difference).HasColumnName("Difference");
            this.Property(t => t.SubTotal1).HasColumnName("SubTotal1");
            this.Property(t => t.SubTotal2).HasColumnName("SubTotal2");
            this.Property(t => t.SubTotal3).HasColumnName("SubTotal3");
            this.Property(t => t.NetClosing).HasColumnName("NetClosing");
            this.Property(t => t.TotalSale).HasColumnName("TotalSale");
            this.Property(t => t.ArtificialJewellerySale).HasColumnName("ArtificialJewellerySale");
            this.Property(t => t.FreeOfCost).HasColumnName("FreeOfCost");
            this.Property(t => t.CostOfGoods).HasColumnName("CostOfGoods");
            this.Property(t => t.GrossProfit).HasColumnName("GrossProfit");
            this.Property(t => t.NetProfit).HasColumnName("NetProfit");
            this.Property(t => t.BankName1).HasColumnName("BankName1");
            this.Property(t => t.BankName2).HasColumnName("BankName2");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
        }
    }
}
