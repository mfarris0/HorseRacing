using HorseRacing.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing.Data
{
    public class HorseRacingDbContext : DbContext
    {

        public DbSet<Track> Tracks { get; set; }

        public DbSet<RaceDay> RaceDays { get; set; }

        public DbSet<Distance> Distances { get; set; }

        public DbSet<RaceSurface> RaceSurfaces { get; set; }

        public DbSet<RaceType> RaceTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HorseRacing");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api
            modelBuilder.Entity<Track>().ToTable(Track.Constants.TableName);
            modelBuilder.Entity<RaceDay>().ToTable(RaceDay.Constants.TableName);
            modelBuilder.Entity<Distance>().ToTable(Distance.Constants.TableName);
            modelBuilder.Entity<RaceSurface>().ToTable(RaceSurface.Constants.TableName);
            modelBuilder.Entity<RaceType>().ToTable(RaceType.Constants.TableName);

            base.OnModelCreating(modelBuilder);
        }
    }

}
