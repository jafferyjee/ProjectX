using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class PaymentTermMap : EntityTypeConfiguration<PaymentTerm>
    {
        public PaymentTermMap()
        {
            // Primary Key
            this.HasKey(t => t.PaymentTermID);

            // Properties
            this.Property(t => t.PaymentTermID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PaymentTermName)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("PaymentTerms");
            this.Property(t => t.PaymentTermID).HasColumnName("PaymentTermID");
            this.Property(t => t.PaymentTermName).HasColumnName("PaymentTermName");
        }
    }
}
