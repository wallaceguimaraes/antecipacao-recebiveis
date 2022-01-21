﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Infrastructure.Context;

namespace api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220121044648_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Pagcerto")
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("api.Models.EntityModel.Portion", b =>
                {
                    b.Property<int>("PortionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("AnticipatedValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpectedDateReceipt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GrossValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InstallmentNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("NetValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("TransferDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransferId")
                        .HasColumnType("int");

                    b.HasKey("PortionId");

                    b.HasIndex("TransferId");

                    b.ToTable("Portions");
                });

            modelBuilder.Entity("api.Models.EntityModel.Situation", b =>
                {
                    b.Property<int>("SituationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("varchar(15)");

                    b.HasKey("SituationId");

                    b.ToTable("Situations");

                    b.HasData(
                        new
                        {
                            SituationId = 1,
                            Description = "PENDENTE"
                        },
                        new
                        {
                            SituationId = 2,
                            Description = "EM ANÁLISE"
                        },
                        new
                        {
                            SituationId = 3,
                            Description = "FINALIZADA"
                        });
                });

            modelBuilder.Entity("api.Models.EntityModel.Transfer", b =>
                {
                    b.Property<int>("TransferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CardDigits")
                        .HasColumnType("varchar(4)");

                    b.Property<string>("ConfirmationAcquirer")
                        .HasColumnType("varchar(8)");

                    b.Property<DateTime>("DateTransferMade")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DisapprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Early")
                        .HasColumnType("bit");

                    b.Property<decimal>("FixedRate")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("GrossTransferAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("InstallmentAmount")
                        .HasColumnType("int");

                    b.Property<decimal>("TransferNetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TransferId");

                    b.ToTable("Transfer");
                });

            modelBuilder.Entity("api.Models.EntityModel.Portion", b =>
                {
                    b.HasOne("api.Models.EntityModel.Transfer", "Transfer")
                        .WithMany("Portions")
                        .HasForeignKey("TransferId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Transfer");
                });

            modelBuilder.Entity("api.Models.EntityModel.Transfer", b =>
                {
                    b.Navigation("Portions");
                });
#pragma warning restore 612, 618
        }
    }
}