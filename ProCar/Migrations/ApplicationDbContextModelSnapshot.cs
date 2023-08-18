﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProCar.Models;

#nullable disable

namespace ProCar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("ProCar.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ProCar.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrandId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CostPerDay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Deposit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DriveTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("EngineСapacity")
                        .HasColumnType("REAL");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GearboxTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TimeDelayCost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearOfIssue")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CarTypeId");

                    b.HasIndex("DriveTypeId");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("GearboxTypeId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ProCar.Models.CarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CarTypes");
                });

            modelBuilder.Entity("ProCar.Models.DriveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DriveTypes");
                });

            modelBuilder.Entity("ProCar.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("ProCar.Models.GearboxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GearboxTypes");
                });

            modelBuilder.Entity("ProCar.Models.Car", b =>
                {
                    b.HasOne("ProCar.Models.Brand", "Brand")
                        .WithMany("Cars")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProCar.Models.CarType", "CarType")
                        .WithMany("Cars")
                        .HasForeignKey("CarTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProCar.Models.DriveType", "DriveType")
                        .WithMany("Cars")
                        .HasForeignKey("DriveTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProCar.Models.FuelType", "FuelType")
                        .WithMany("Cars")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProCar.Models.GearboxType", "GearboxType")
                        .WithMany("Cars")
                        .HasForeignKey("GearboxTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("CarType");

                    b.Navigation("DriveType");

                    b.Navigation("FuelType");

                    b.Navigation("GearboxType");
                });

            modelBuilder.Entity("ProCar.Models.Brand", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ProCar.Models.CarType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ProCar.Models.DriveType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ProCar.Models.FuelType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ProCar.Models.GearboxType", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
