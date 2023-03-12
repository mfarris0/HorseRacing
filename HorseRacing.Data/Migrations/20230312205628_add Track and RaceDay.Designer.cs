﻿// <auto-generated />
using System;
using HorseRacing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HorseRacing.Data.Migrations
{
    [DbContext(typeof(HorseRacingDbContext))]
    [Migration("20230312205628_add Track and RaceDay")]
    partial class addTrackandRaceDay
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HorseRacing.Domain.RaceDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RaceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("TrackId")
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("RaceDay");
                });

            modelBuilder.Entity("HorseRacing.Domain.Track", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("BRISCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Track");
                });

            modelBuilder.Entity("HorseRacing.Domain.RaceDay", b =>
                {
                    b.HasOne("HorseRacing.Domain.Track", "Track")
                        .WithMany()
                        .HasForeignKey("TrackId");

                    b.Navigation("Track");
                });
#pragma warning restore 612, 618
        }
    }
}
