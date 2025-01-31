﻿// <auto-generated />
using EFCore3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore3.Migrations
{
    [DbContext(typeof(DataContex))]
    [Migration("20231201042947_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EFCore3.Models.College", b =>
                {
                    b.Property<int>("CollegeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CollegeAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CollegeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CollegeType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("CollegeId");

                    b.HasIndex("UniversityId");

                    b.ToTable("college");

                    b.HasData(
                        new
                        {
                            CollegeId = 1,
                            CollegeAddress = "123 College Street 1",
                            CollegeName = "Engineering College 1",
                            CollegeType = "Technical",
                            UniversityId = 1
                        },
                        new
                        {
                            CollegeId = 2,
                            CollegeAddress = "123 College Street 2",
                            CollegeName = "Engineering College 2",
                            CollegeType = "Technical",
                            UniversityId = 1
                        },
                        new
                        {
                            CollegeId = 3,
                            CollegeAddress = "123 College Street 3",
                            CollegeName = "Engineering College 3",
                            CollegeType = "Technical",
                            UniversityId = 2
                        },
                        new
                        {
                            CollegeId = 4,
                            CollegeAddress = "123 College Street 4",
                            CollegeName = "Engineering College 4",
                            CollegeType = "Technical",
                            UniversityId = 2
                        },
                        new
                        {
                            CollegeId = 5,
                            CollegeAddress = "123 College Street 5",
                            CollegeName = "Engineering College 5",
                            CollegeType = "Technical",
                            UniversityId = 3
                        },
                        new
                        {
                            CollegeId = 6,
                            CollegeAddress = "123 College Street 6",
                            CollegeName = "Engineering College 6",
                            CollegeType = "Technical",
                            UniversityId = 3
                        });
                });

            modelBuilder.Entity("EFCore3.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CollegeId")
                        .HasColumnType("int");

                    b.Property<string>("DepartmentHead")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NuumberOfClass")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId");

                    b.HasIndex("CollegeId");

                    b.ToTable("department");
                });

            modelBuilder.Entity("EFCore3.Models.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("ProfessorAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProfessorAge")
                        .HasColumnType("int");

                    b.Property<string>("ProfessorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("ProfessorId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("professor");
                });

            modelBuilder.Entity("EFCore3.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("StudentAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("StudentMarks")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("StudentPercentage")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("StudentResult")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("student");
                });

            modelBuilder.Entity("EFCore3.Models.University", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UnversityAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UnversityType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UnvesrsityGrade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UniversityId");

                    b.ToTable("universitie");

                    b.HasData(
                        new
                        {
                            UniversityId = 1,
                            UniversityName = "Harvard University",
                            UnversityAddress = "Cambridge, Massachusetts",
                            UnversityType = "Private",
                            UnvesrsityGrade = "A+"
                        },
                        new
                        {
                            UniversityId = 2,
                            UniversityName = "MIT",
                            UnversityAddress = "Cambridge, Massachusetts",
                            UnversityType = "Private",
                            UnvesrsityGrade = "A"
                        },
                        new
                        {
                            UniversityId = 3,
                            UniversityName = "Stanford University",
                            UnversityAddress = "Stanford, California",
                            UnversityType = "Private",
                            UnvesrsityGrade = "A+"
                        });
                });

            modelBuilder.Entity("EFCore3.Models.College", b =>
                {
                    b.HasOne("EFCore3.Models.University", "University")
                        .WithMany("Colleges")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("EFCore3.Models.Department", b =>
                {
                    b.HasOne("EFCore3.Models.College", "College")
                        .WithMany("Departments")
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");
                });

            modelBuilder.Entity("EFCore3.Models.Professor", b =>
                {
                    b.HasOne("EFCore3.Models.Department", "Department")
                        .WithMany("Professors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EFCore3.Models.Student", b =>
                {
                    b.HasOne("EFCore3.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EFCore3.Models.College", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("EFCore3.Models.Department", b =>
                {
                    b.Navigation("Professors");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("EFCore3.Models.University", b =>
                {
                    b.Navigation("Colleges");
                });
#pragma warning restore 612, 618
        }
    }
}
