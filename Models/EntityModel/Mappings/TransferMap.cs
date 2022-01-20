using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Models.EntityModel.Mappings
{
    public class TransferMap : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transfer> builder)
        {
            builder.ToTable("Transfer");

            builder.HasKey(a => a.TransferId);

            builder.Property(a => a.ConfirmationAcquirer)
                .HasColumnType("varchar(8)");

            builder.Property(a => a.GrossTransferAmount)
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.TransferNetAmount)
                .HasColumnType("decimal(18,2)");


            builder.Property(a => a.FixedRate)
               .HasColumnType("decimal(5,2)")
                .IsRequired(true);

            builder.Property(a => a.CardDigits)
                .HasPrecision(4);
        }
    }
}