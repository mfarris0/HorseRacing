using HorseRacing.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HorseRacing.Data
{
    public class HorseRacingDbContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public HorseRacingDbContext()
        {

        }

        public HorseRacingDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //public HorseRacingDbContext(DbContextOptions<HorseRacingDbContext> options) : base(options)
        //{

        //}

        public DbSet<Track> Tracks { get; set; }

        public DbSet<RaceDay> RaceDays { get; set; }

        public DbSet<Distance> Distances { get; set; }

        public DbSet<RaceSurface> RaceSurfaces { get; set; }

        public DbSet<RaceType> RaceTypes { get; set; }

        public DbSet<RawRace> RawRaces { get; set; }

        public DbSet<RawRaceHorse> RawRaceHorses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database"));
            //"Server=.\SQLExpress;AttachDbFilename=|DataDirectory|\HorseRacing.mdf;Database=HorseRacing;Trusted_Connection=Yes;"

            const string HorseRacingConnectionString = "HorseRacingConnectionString";

            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HorseRacing");
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString(HorseRacingConnectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api
            modelBuilder.Entity<Track>().ToTable(Track.Constants.TableName);
            modelBuilder.Entity<RaceDay>().ToTable(RaceDay.Constants.TableName);
            modelBuilder.Entity<Distance>().ToTable(Distance.Constants.TableName);
            modelBuilder.Entity<RaceSurface>().ToTable(RaceSurface.Constants.TableName);
            modelBuilder.Entity<RaceType>().ToTable(RaceType.Constants.TableName);
            modelBuilder.Entity<RawRace>().ToTable(RawRace.Constants.TableName);
            modelBuilder.Entity<RawRaceHorse>().ToTable(RawRaceHorse.Constants.TableName);

            base.OnModelCreating(modelBuilder);
        }
    }

}
