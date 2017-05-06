using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectX.Entities.Models.Mapping
{
    public class ColorMap : EntityTypeConfiguration<Color>
    {
        public ColorMap()
        {
            // Primary Key
            this.HasKey(t => t.ColorCode);

            // Properties
            this.Property(t => t.ColorCode)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.ColorName)
                .HasMaxLength(32);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(32);

            this.Property(t => t.ModifiedBy)
                .HasMaxLength(32);

            // Table & Column Mappings
            this.ToTable("Colors");
            this.Property(t => t.ColorCode).HasColumnName("ColorCode");
            this.Property(t => t.ColorName).HasColumnName("ColorName");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

            // Relationships
            this.HasMany(t => t.SubInventories)
                .WithMany(t => t.Colors)
                .Map(m =>
                    {
                        m.ToTable("SubInventoryColors");
                        m.MapLeftKey("ColorCode");
                        m.MapRightKey("SubInvCode");
                    });


        }
    }
}
