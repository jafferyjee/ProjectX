using System;
using System.Collections.Generic;

namespace ProjectX.Entities.Models
{
    public partial class Session
    {
        public Session()
        {
            this.DocumentDatas = new List<DocumentData>();
            this.DocumentNumbers = new List<DocumentNumber>();
        }

        public string SessionUnqRef { get; set; }
        public Nullable<bool> IsClosed { get; set; }
        public string BranchCode { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> OpeningBal { get; set; }
        public Nullable<decimal> Expense { get; set; }
        public Nullable<decimal> BankDeposit1 { get; set; }
        public Nullable<decimal> SalesInvoice { get; set; }
        public Nullable<decimal> ReplacementInvoice { get; set; }
        public Nullable<decimal> OrderBooking { get; set; }
        public Nullable<decimal> CreditVoucher { get; set; }
        public Nullable<decimal> GiftVoucher { get; set; }
        public Nullable<decimal> PersonalCrRetrieved { get; set; }
        public Nullable<decimal> Refund { get; set; }
        public Nullable<decimal> CreditCard { get; set; }
        public Nullable<decimal> SalesReturn { get; set; }
        public Nullable<decimal> ReplacementReturn { get; set; }
        public Nullable<decimal> CancelledOrder { get; set; }
        public Nullable<decimal> CreditVoucherRedeemed { get; set; }
        public Nullable<decimal> GiftVoucherRedeemed { get; set; }
        public Nullable<decimal> PersonalCrIssued { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> ManualDiscount { get; set; }
        public Nullable<decimal> CashToHO { get; set; }
        public Nullable<decimal> BankDeposit2 { get; set; }
        public Nullable<decimal> CashInHand { get; set; }
        public Nullable<decimal> CashFromHO { get; set; }
        public Nullable<decimal> ExtraSale { get; set; }
        public Nullable<decimal> Difference { get; set; }
        public Nullable<decimal> SubTotal1 { get; set; }
        public Nullable<decimal> SubTotal2 { get; set; }
        public Nullable<decimal> SubTotal3 { get; set; }
        public Nullable<decimal> NetClosing { get; set; }
        public Nullable<decimal> TotalSale { get; set; }
        public Nullable<decimal> ArtificialJewellerySale { get; set; }
        public Nullable<decimal> FreeOfCost { get; set; }
        public Nullable<decimal> CostOfGoods { get; set; }
        public Nullable<decimal> GrossProfit { get; set; }
        public Nullable<decimal> NetProfit { get; set; }
        public string BankName1 { get; set; }
        public string BankName2 { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<DocumentData> DocumentDatas { get; set; }
        public virtual ICollection<DocumentNumber> DocumentNumbers { get; set; }
    }
}
