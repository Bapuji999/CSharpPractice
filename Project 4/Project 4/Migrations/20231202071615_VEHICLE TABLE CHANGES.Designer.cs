﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_4;

#nullable disable

namespace Project_4.Migrations
{
    [DbContext(typeof(Contex))]
    [Migration("20231202071615_VEHICLE TABLE CHANGES")]
    partial class VEHICLETABLECHANGES
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Project_4.Models.PaymentDetails", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsAdvancePaymentDone")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsFullPaymentDone")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("TotalPayment")
                        .HasColumnType("double");

                    b.Property<double>("TotalRent")
                        .HasColumnType("double");

                    b.Property<int>("VehicleIssueId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.ToTable("PaymentDetails");
                });

            modelBuilder.Entity("Project_4.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LicenceNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin1@gmail.com",
                            IsAdmin = true,
                            IsDeleted = false,
                            LicenceNo = "",
                            Password = "",
                            Phone = "",
                            UserName = "Admin1",
                            UserTypeId = 1
                        });
                });

            modelBuilder.Entity("Project_4.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserTypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserType");

                    b.HasData(
                        new
                        {
                            UserTypeId = 1,
                            UserTypeName = "Gold"
                        },
                        new
                        {
                            UserTypeId = 2,
                            UserTypeName = "Silver"
                        },
                        new
                        {
                            UserTypeId = 3,
                            UserTypeName = "Platinum"
                        });
                });

            modelBuilder.Entity("Project_4.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("PerDayPrice")
                        .HasColumnType("double");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("VehicleNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Project_4.Models.VehicleIssue", b =>
                {
                    b.Property<int>("VehicleIssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("VehicleIssueId");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleIssue");
                });

            modelBuilder.Entity("Project_4.Models.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("VehicleTypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("VehicleType");

                    b.HasData(
                        new
                        {
                            VehicleTypeId = 1,
                            VehicleTypeName = "SUV"
                        },
                        new
                        {
                            VehicleTypeId = 2,
                            VehicleTypeName = "Jeep"
                        },
                        new
                        {
                            VehicleTypeId = 3,
                            VehicleTypeName = "Van"
                        },
                        new
                        {
                            VehicleTypeId = 4,
                            VehicleTypeName = "Wagon"
                        },
                        new
                        {
                            VehicleTypeId = 5,
                            VehicleTypeName = "Coupe"
                        });
                });

            modelBuilder.Entity("Project_4.Models.VehicleIssue", b =>
                {
                    b.HasOne("Project_4.Models.User", "User")
                        .WithMany("VehicleIssue")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_4.Models.Vehicle", "vehicle")
                        .WithMany("VehicleIssue")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project_4.Models.PaymentDetails", "PaymentDetails")
                        .WithOne("VehicleIssue")
                        .HasForeignKey("Project_4.Models.VehicleIssue", "VehicleIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentDetails");

                    b.Navigation("User");

                    b.Navigation("vehicle");
                });

            modelBuilder.Entity("Project_4.Models.PaymentDetails", b =>
                {
                    b.Navigation("VehicleIssue")
                        .IsRequired();
                });

            modelBuilder.Entity("Project_4.Models.User", b =>
                {
                    b.Navigation("VehicleIssue");
                });

            modelBuilder.Entity("Project_4.Models.Vehicle", b =>
                {
                    b.Navigation("VehicleIssue");
                });
#pragma warning restore 612, 618
        }
    }
}
