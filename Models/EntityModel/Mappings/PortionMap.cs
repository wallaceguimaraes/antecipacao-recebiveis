using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Mappings
{
    public class PortionMap : IEntityTypeConfiguration<Portion>
    {
        public void Configure(EntityTypeBuilder<Portion> builder)
        {
            builder.ToTable("Portions");

            builder.HasKey(a => a.PortionId);

            builder.HasOne(a => a.Transfer)
                    .WithMany(a => a.Portions)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);


            builder.Property(a => a.GrossValue)
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.NetValue)
                .HasColumnType("decimal(18,2)");
        }
    }
}
