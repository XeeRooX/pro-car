﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProCar.Models;

#nullable disable

namespace ProCar.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250130060052_AddDefaultContacts")]
    partial class AddDefaultContacts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CarColor", b =>
                {
                    b.Property<int>("CarsId")
                        .HasColumnType("int");

                    b.Property<int>("ColorsId")
                        .HasColumnType("int");

                    b.HasKey("CarsId", "ColorsId");

                    b.HasIndex("ColorsId");

                    b.ToTable("CarColor");
                });

            modelBuilder.Entity("ProCar.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("ProCar.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CostPerDay")
                        .HasColumnType("int");

                    b.Property<int>("Deposit")
                        .HasColumnType("int");

                    b.Property<int>("DriveTypeId")
                        .HasColumnType("int");

                    b.Property<double>("EngineСapacity")
                        .HasColumnType("double");

                    b.Property<string>("Equipment")
                        .HasColumnType("longtext");

                    b.Property<int>("FuelTypeId")
                        .HasColumnType("int");

                    b.Property<int>("GearboxTypeId")
                        .HasColumnType("int");

                    b.Property<double?>("Horsepower")
                        .HasColumnType("double");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TimeDelayCost")
                        .HasColumnType("int");

                    b.Property<int>("YearOfIssue")
                        .HasColumnType("int");

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
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CarTypes");
                });

            modelBuilder.Entity("ProCar.Models.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("ProCar.Models.ContactDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MapPoint")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ContactDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "г. Оренбург, ул. Одесская, 23",
                            Email = "proavtooren@yandex.ru",
                            MapPoint = "https://api-maps.yandex.ru/services/constructor/1.0/js/?um=constructor%3Ae15ba2ef1d406f5e87f54c6717959fd2adddc1f41e48301d66d7136c56266532&amp;width=100%25&amp;height=600&amp;lang=ru_RU&amp;scroll=false",
                            PhoneNumber = "+7 969 749 00-43"
                        });
                });

            modelBuilder.Entity("ProCar.Models.DriveType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DriveTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "передний"
                        },
                        new
                        {
                            Id = 2,
                            Name = "полный"
                        },
                        new
                        {
                            Id = 3,
                            Name = "задний"
                        });
                });

            modelBuilder.Entity("ProCar.Models.FuelType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "бензин"
                        },
                        new
                        {
                            Id = 2,
                            Name = "дизель"
                        },
                        new
                        {
                            Id = 3,
                            Name = "электричество"
                        },
                        new
                        {
                            Id = 4,
                            Name = "пропан"
                        },
                        new
                        {
                            Id = 5,
                            Name = "метан"
                        });
                });

            modelBuilder.Entity("ProCar.Models.GearboxType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("GearboxTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "механическая"
                        },
                        new
                        {
                            Id = 2,
                            Name = "автомат"
                        },
                        new
                        {
                            Id = 3,
                            Name = "вариатор"
                        },
                        new
                        {
                            Id = 4,
                            Name = "робот"
                        });
                });

            modelBuilder.Entity("ProCar.Models.SocialNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SocialNetworks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "telegram",
                            Link = "https://t.me/yandex_taxi23",
                            Name = "Телеграм"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "whatsapp",
                            Link = "https://wa.me/79697490043",
                            Name = "whats app"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "instagram",
                            Link = "https://www.instagram.com/fgfdg",
                            Name = "instagram"
                        });
                });

            modelBuilder.Entity("CarColor", b =>
                {
                    b.HasOne("ProCar.Models.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProCar.Models.Color", null)
                        .WithMany()
                        .HasForeignKey("ColorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
