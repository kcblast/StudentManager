﻿// <auto-generated />
using System;
using Application_API_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application_API_Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application_API_Core.Models.Entities.Course", b =>
                {
                    b.Property<Guid>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseCode");

                    b.Property<DateTime>("CourseSchudle");

                    b.Property<string>("CourseTeacher");

                    b.Property<string>("CourseTitle");

                    b.Property<Guid>("StudentId");

                    b.HasKey("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = new Guid("2902b665-1190-4c70-9915-b9c2d7680450"),
                            CourseCode = "Cit409",
                            CourseSchudle = new DateTime(2020, 7, 22, 10, 40, 47, 92, DateTimeKind.Local).AddTicks(9509),
                            CourseTeacher = "Mr John",
                            CourseTitle = "Introduction to Networking",
                            StudentId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35")
                        });
                });

            modelBuilder.Entity("Application_API_Core.Models.Entities.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MatricNumber");

                    b.Property<string>("StudentLevel");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            FirstName = "Kelechi",
                            LastName = "Onu",
                            MatricNumber = "Nou152094338",
                            StudentLevel = "400"
                        },
                        new
                        {
                            StudentId = new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                            FirstName = "Victor",
                            LastName = "Maxi",
                            MatricNumber = "Nou123456789",
                            StudentLevel = "400"
                        });
                });

            modelBuilder.Entity("Application_API_Core.Models.Entities.Course", b =>
                {
                    b.HasOne("Application_API_Core.Models.Entities.Student", "Students")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}