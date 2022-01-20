using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models.EntityModel.Mappings;
using api.Models.EntityModel;

namespace api.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public const string Schema = "Pagcerto";
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Portion> Portions { get; set; }


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

        }
    }

}