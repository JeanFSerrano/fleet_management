﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using fleet_management.Data;

#nullable disable

namespace fleet_management.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231106143714_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("fleet_management.Models.Fleet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<Guid?>("VehicleModelId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("Fleet");
                });

            modelBuilder.Entity("fleet_management.Models.FleetWithVehicleCount", b =>
                {
                    b.Property<string>("Fleet")
                        .HasColumnType("text");

                    b.Property<int>("VehicleCount")
                        .HasColumnType("integer");

                    b.Property<List<string>>("VehicleName")
                        .HasColumnType("text[]");

                    b.ToTable("FleetAndVehicles");
                });

            modelBuilder.Entity("fleet_management.Models.VehicleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brand")
                        .HasColumnType("text");

                    b.Property<Guid>("FleetId")
                        .HasColumnType("uuid");

                    b.Property<long>("KmDriven")
                        .HasColumnType("bigint");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("NormalDoors")
                        .HasColumnType("smallint");

                    b.Property<byte>("RunningDoors")
                        .HasColumnType("smallint");

                    b.Property<int>("Seats")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("fleet_management.Models.Fleet", b =>
                {
                    b.HasOne("fleet_management.Models.VehicleModel", null)
                        .WithMany("Fleets")
                        .HasForeignKey("VehicleModelId");
                });

            modelBuilder.Entity("fleet_management.Models.VehicleModel", b =>
                {
                    b.Navigation("Fleets");
                });
#pragma warning restore 612, 618
        }
    }
}