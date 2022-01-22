using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Mappings
{
    public class RequestSituationMap : IEntityTypeConfiguration<RequestSituation>
    {
        public void Configure(EntityTypeBuilder<RequestSituation> builder)
        {

            builder.ToTable("RequestSituations");

            builder.HasKey(a => a.RequestSituationId);

            builder.HasOne(a => a.AdvanceRequest)
                   .WithMany(a => a.RequestedSituations)
                   .HasForeignKey("AdvanceRequestId")
                        .HasConstraintName("fk_requested_situation__fk_advance_request")
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);
                  
            
            builder.HasOne(a => a.Situation)
                   .WithMany(a => a.RequestSituations)
                    .HasForeignKey("SituationId")
                        .HasConstraintName("fk_requested_situation__fk_situation")
                         .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

        }
    }
}