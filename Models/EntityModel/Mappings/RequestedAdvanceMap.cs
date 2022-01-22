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

        }
    }
}