using api.Models.EntityModel;
using api.Models.EntityModel.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace api.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public const string Schema = "Pagcerto";
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Portion> Portions { get; set; }
        public DbSet<AdvanceRequest> AdvanceRequests { get; set; }
        public DbSet<RequestedAdvance> RequestedAdvances { get; set; }

        public DbSet<RequestSituation> RequestSituations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.ApplyConfiguration(new SituationMap());
            modelBuilder.Entity<Situation>()
                        .HasData(new List<Situation>(){
                                    new Situation(1, "PENDENTE"),
                                    new Situation(2, "EM ANÁLISE"),
                                    new Situation(3, "FINALIZADA")
                        });
            modelBuilder.ApplyConfiguration(new TransferMap());
            modelBuilder.ApplyConfiguration(new PortionMap());
            modelBuilder.ApplyConfiguration(new AdvanceRequestMap());
            modelBuilder.ApplyConfiguration(new RequestedAdvanceMap());
            modelBuilder.ApplyConfiguration(new RequestSituationMap());

        }
    }

}