using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            // Primary Key
            this.HasKey(t => t.ContactFullCode);

            // Properties
            this.Property(t => t.ContactFullCode)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.ContactTypeCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.ContactCategoryCode)
                .HasMaxLength(50);

            this.Property(t => t.ContactCode)
                .IsRequired()
                .HasMaxLength(32);

            this.Property(t => t.ContactName)
                .HasMaxLength(64);

            this.Property(t => t.LevelContactFullCode)
                .HasMaxLength(64);

            this.Property(t => t.BranchCode)
                .HasMaxLength(16);

            this.Property(t => t.Salutation)
                .HasMaxLength(4);

            this.Property(t => t.FullName)
                .HasMaxLength(128);

            this.Property(t => t.FirstName)
                .HasMaxLength(32);

            this.Property(t => t.MiddleName)
                .HasMaxLength(32);

            this.Property(t => t.LastName)
                .HasMaxLength(32);

            this.Property(t => t.CompanyName)
                .HasMaxLength(128);

            this.Property(t => t.Relation)
                .HasMaxLength(32);

            this.Property(t => t.Title)
                .HasMaxLength(32);

            this.Property(t => t.Department)
                .HasMaxLength(32);

            this.Property(t => t.Address)
                .HasMaxLength(256);

            this.Property(t => t.City)
                .HasMaxLength(32);

            this.Property(t => t.PostalCode)
                .HasMaxLength(32);

            this.Property(t => t.Country)
                .HasMaxLength(32);

            this.Property(t => t.PhoneMobile)
                .HasMaxLength(32);

            this.Property(t => t.PhoneDirect)
                .HasMaxLength(16);

            this.Property(t => t.PhoneExt)
                .HasMaxLength(16);

            this.Property(t => t.Fax)
                .HasMaxLength(16);

            this.Property(t => t.Email)
                .HasMaxLength(32);

            this.Property(t => t.CardFormNo)
                .HasMaxLength(32);

            this.Property(t => t.CNIC)
                .HasMaxLength(50);

            this.Property(t => t.Occupation)
                .HasMaxLength(50);

            this.Property(t => t.Photo)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Contacts");
            this.Property(t => t.ContactFullCode).HasColumnName("ContactFullCode");
            this.Property(t => t.ContactTypeCode).HasColumnName("ContactTypeCode");
            this.Property(t => t.ContactCategoryCode).HasColumnName("ContactCategoryCode");
            this.Property(t => t.ContactCode).HasColumnName("ContactCode");
            this.Property(t => t.ContactName).HasColumnName("ContactName");
            this.Property(t => t.LevelContactFullCode).HasColumnName("LevelContactFullCode");
            this.Property(t => t.IsTransaction).HasColumnName("IsTransaction");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.BranchCode).HasColumnName("BranchCode");
            this.Property(t => t.Salutation).HasColumnName("Salutation");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.Relation).HasColumnName("Relation");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Department).HasColumnName("Department");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.PhoneMobile).HasColumnName("PhoneMobile");
            this.Property(t => t.PhoneDirect).HasColumnName("PhoneDirect");
            this.Property(t => t.PhoneExt).HasColumnName("PhoneExt");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.CardFormNo).HasColumnName("CardFormNo");
            this.Property(t => t.CardIssueDate).HasColumnName("CardIssueDate");
            this.Property(t => t.CardExpiryDate).HasColumnName("CardExpiryDate");
            this.Property(t => t.DiscountPer).HasColumnName("DiscountPer");
            this.Property(t => t.DiscountAmt).HasColumnName("DiscountAmt");
            this.Property(t => t.CNIC).HasColumnName("CNIC");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.Occupation).HasColumnName("Occupation");
            this.Property(t => t.WeddingAnni).HasColumnName("WeddingAnni");
            this.Property(t => t.CardStatus).HasColumnName("CardStatus");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasOptional(t => t.ContactCategory)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.ContactCategoryCode);
            this.HasRequired(t => t.ContactType)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.ContactTypeCode);

        }
    }
}
