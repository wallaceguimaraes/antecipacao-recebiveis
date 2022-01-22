using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Mappings
{
    public class RequestedAdvanceMap : IEntityTypeConfiguration<RequestedAdvance>
    {
        public void Configure(EntityTypeBuilder<RequestedAdvance> builder)
        {
            builder.ToTable("RequestedAdvance");

            builder.HasKey(a => a.RequestedAdvanceId);

            builder.HasOne(a => a.Transfer)
                            .WithOne(a => a.RequestedAdvance)
                                    .IsRequired()
                                    .OnDelete(DeleteBehavior.Cascade);

                    builder.HasOne(a => a.AdvanceRequest)
                   .WithMany(a => a.RequestedAdvances)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);
                  
        }
    }
}