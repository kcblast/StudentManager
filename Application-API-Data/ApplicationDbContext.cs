using Application_API_Core.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_API_Data
{
   public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        //{
        //    public ApplicationDbContext Create(DbContextFactoryOptions options)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //        return new ApplicationDbContext(optionsBuilder.Options);
        //    }

        //    public ApplicationDbContext CreateDbContext(string[] args)
        //    {

        //        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //        return new ApplicationDbContext(optionsBuilder.Options);
        //    }
        //}

        //public class DataContextFactory : IDbContextFactory<ApplicationDbContext>
        //{
        //    public DataContextFactory()
        //    {
        //    }

        //    public ApplicationDbContext Create(DbContextFactoryOptions options)
        //    {
        //        // Used only for EF .NET Core CLI tools (update database/migrations etc.)
        //        var builder = new ConfigurationBuilder()
        //            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
        //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        //        var config = builder.Build();

        //        var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
        //            .UseSqlServer(config.GetConnectionString("SearchDataContext"));

        //        return new DataContext(optionsBuilder.Options);
        //    }
        //}


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {



            builder.Entity<Student>().HasData(new Student()
            {
                StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54F9b35"),
                FirstName = "Kelechi",
                LastName = "Onu",
                MatricNumber = "Nou152094338",
                StudentLevel = "400",


            },
            new Student()
            {
                StudentId = Guid.Parse("da2fd609-d754-4Feb-8acd-c4f9ff13ba96"),
                FirstName = "Victor",
                LastName = "Maxi",
                MatricNumber = "Nou123456789",
                StudentLevel = "400",
            }
            );


            builder.Entity<Course>().HasData(new Course()
            {
                CourseId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                CourseTitle = "Introduction to Networking",
                CourseCode = "Cit409",
                CourseTeacher = "Mr John",
                CourseSchudle = DateTime.Now,
                StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54F9b35"),
            });
            new Course()
            {
                CourseId = Guid.Parse("7902b665-2290-4c70-8815-b9c2d7689850"),
                CourseTitle = "Introduction to Networking",
                CourseCode = "Cit409",
                CourseTeacher = "Mr John",
                CourseSchudle = DateTime.Now,
                StudentId = Guid.Parse("da2fd609-d754-4Feb-8acd-c4f9ff13ba96"),
            };
        }




    }
}
