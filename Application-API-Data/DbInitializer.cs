using Application_API_Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_API_Data
{
   public static class DbInitializer
    {
        //public static async Task InitializerAsync(IServiceProvider serviceProvider)
        //{
        //    using (var context = serviceProvider.CreateScope())
        //    {
        //        var scopeServiceProvider = context.ServiceProvider;
        //        var db = scopeServiceProvider.GetService<ApplicationDbContext>();
        //        db.Database.Migrate();
        //        await InsertTestData(db);
        //    }
        //}
        //private static async  Task InsertTestData(ApplicationDbContext context)
        //{
        //    if (context.Students.Any())
        //        return;
        //    var _student = new Student
        //    {
        //        StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54F9b35"),
        //        FirstName = "Kelechi",
        //        LastName = "Onu",
        //        MatricNumber = "Nou152094338",
        //        StudentLevel = "400"
        //    };
        //    context.Add(_student);
        //    await context.SaveChangesAsync();

        //    if (context.Courses.Any())
        //    {
        //        var _course = new Course
        //        {
        //            CourseId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
        //            CourseTitle = "Introduction to Networking",
        //            CourseCode = "Cit409",
        //            CourseTeacher = "Mr John",
        //            CourseSchudle = DateTime.Now,
        //            StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54F9b35")
        //        };
        //    }
        
        //}
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Students.Any())
            {
                context.Students.Add(entity: new Student()
                {
                    StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54F9b35"),
                   // StudentId = new Guid(),
                    FirstName = "Kelechi",
                    LastName = "Onu",
                    MatricNumber = "Nou152094338",
                    StudentLevel = "400"
                });
                context.Students.Add(entity: new Student()
                {
                    StudentId = Guid.Parse("da2fd609-d754-4Feb-8acd-c4f9ff13ba96"),
                   // StudentId = new Guid(),
                    FirstName = "Victor",
                    LastName = "Maxi",
                    MatricNumber = "Nou123456789",
                    StudentLevel = "400",
                });

                context.SaveChanges();
            }

            if (!context.Courses.Any())
            {
                context.Courses.Add(entity: new Course()
                {
                    CourseId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    CourseTitle = "Introduction to Networking",
                    CourseCode = "Cit409",
                    CourseTeacher = "Mr John",
                    CourseSchudle = DateTime.Now,
                    StudentId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54F9b35")
                });

                context.Courses.Add(entity: new Course()
                {
                    CourseId = Guid.Parse("7902b665-2290-4c70-8815-b9c2d7689850"),
                    CourseTitle = "Introduction to Networking",
                    CourseCode = "Cit409",
                    CourseTeacher = "Mr John",
                    CourseSchudle = DateTime.Now,
                    StudentId = Guid.Parse("da2fd609-d754-4Feb-8acd-c4f9ff13ba96")
                });

                context.SaveChanges();
            }
        }
    }
}
