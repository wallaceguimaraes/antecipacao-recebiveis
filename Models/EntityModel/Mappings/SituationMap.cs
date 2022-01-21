using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Mappings
{
    public class SituationMap : IEntityTypeConfiguration<Situation>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Situation> builder)
        {

            builder.ToTable("Situations");

            builder.HasKey(a => a.SituationId);

            builder.Property(a => a.Description)
                .HasColumnType("varchar(15)");

        }

    }
}