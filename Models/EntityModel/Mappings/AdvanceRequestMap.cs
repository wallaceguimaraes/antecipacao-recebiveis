using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Models.EntityModel.Mappings
{
    public class AdvanceRequestMap: IEntityTypeConfiguration<AdvanceRequest>
    {
        public void Configure(EntityTypeBuilder<AdvanceRequest> builder)
        {
            builder.ToTable("AdvanceRequest");

            builder.HasKey(a => a.AdvanceRequestId);


            builder.Property(a => a.AmountRequestedAdvance)
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.AnticipatedValue)
                .HasColumnType("decimal(18,2)");
        }
                   
    }
}