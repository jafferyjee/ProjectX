using Northwind.Entities.Context;
using Northwind.Entities.Models;
using Northwind.Entities.Models.Mapping;
using System.Data.Entity;

namespace Northwind.Entities.Models
{
    public partial class NorthwindContext : BaseContext<NorthwindContext>
    {
        //static NorthwindContext()
        //{
        //    Database.SetInitializer<NorthwindContext>(null);
        //}

        //public NorthwindContext()
        //    : base("Name=NorthwindContext")
        //{
        //}

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<DocumentData> DocumentDatas { get; set; }
        public DbSet<DocumentNumber> DocumentNumbers { get; set; }
        public DbSet<DocumentSize> DocumentSizes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<ItemColorSize> ItemColorSizes { get; set; }
        public DbSet<ItemMainCategory> ItemMainCategories { get; set; }
        public DbSet<ItemPrice> ItemPrices { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemStock> ItemStocks { get; set; }
        public DbSet<ItemSubCategory> ItemSubCategories { get; set; }
        public DbSet<PaymentTerm> PaymentTerms { get; set; }
        public DbSet<Range> Ranges { get; set; }
        public DbSet<SeasonalSale> SeasonalSales { get; set; }
        public DbSet<SeasonalSaleDetail> SeasonalSaleDetails { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SubInventory> SubInventories { get; set; }
        public DbSet<SubInventorySizeRange> SubInventorySizeRanges { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<webpages_Membership> webpages_Membership { get; set; }
        public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
        public DbSet<webpages_Roles> webpages_Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BranchMap());
            modelBuilder.Configurations.Add(new ColorMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new ContactTypeMap());
            modelBuilder.Configurations.Add(new DocumentDataMap());
            modelBuilder.Configurations.Add(new DocumentNumberMap());
            modelBuilder.Configurations.Add(new DocumentSizeMap());
            modelBuilder.Configurations.Add(new DocumentTypeMap());
            modelBuilder.Configurations.Add(new ItemColorSizeMap());
            modelBuilder.Configurations.Add(new ItemMainCategoryMap());
            modelBuilder.Configurations.Add(new ItemPriceMap());
            modelBuilder.Configurations.Add(new ItemMap());
            modelBuilder.Configurations.Add(new ItemStockMap());
            modelBuilder.Configurations.Add(new ItemSubCategoryMap());
            modelBuilder.Configurations.Add(new PaymentTermMap());
            modelBuilder.Configurations.Add(new RangeMap());
            modelBuilder.Configurations.Add(new SeasonalSaleMap());
            modelBuilder.Configurations.Add(new SeasonalSaleDetailMap());
            modelBuilder.Configurations.Add(new SessionMap());
            modelBuilder.Configurations.Add(new SizeMap());
            modelBuilder.Configurations.Add(new SubInventoryMap());
            modelBuilder.Configurations.Add(new SubInventorySizeRangeMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new webpages_MembershipMap());
            modelBuilder.Configurations.Add(new webpages_OAuthMembershipMap());
            modelBuilder.Configurations.Add(new webpages_RolesMap());
        }
    }
}