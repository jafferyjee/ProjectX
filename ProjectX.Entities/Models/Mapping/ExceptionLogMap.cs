using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ExceptionLogMap : EntityTypeConfiguration<ExceptionLog>
    {
        public ExceptionLogMap()
        {
            // Primary Key
            this.HasKey(t => t.ExceptionLogID);

            // Properties
            this.Property(t => t.ExceptionType)
                .HasMaxLength(100);

            this.Property(t => t.ExceptionMessage)
                .HasMaxLength(2000);

            this.Property(t => t.StackTrace)
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("ExceptionLog");
            this.Property(t => t.ExceptionLogID).HasColumnName("ExceptionLogID");
            this.Property(t => t.ExceptionType).HasColumnName("ExceptionType");
            this.Property(t => t.ExceptionMessage).HasColumnName("ExceptionMessage");
            this.Property(t => t.StackTrace).HasColumnName("StackTrace");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
        }
    }
}
