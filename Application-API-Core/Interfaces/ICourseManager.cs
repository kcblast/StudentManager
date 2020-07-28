using Application_API_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_API_Core.Interfaces
{
    public interface ICourseManager
    {
        IEnumerable<Course> GetCourses();
        Course GetCourse(Guid CourseId);
        IEnumerable<Course> GetStudentCourses(Guid StudentId);
        Course GetCourseForStudent(Guid StudentId, Guid CourseId);
        //Course GetCoursesForStudent(Guid StudentId);
        void RegisterCourse(Guid StudentId, Course course);
        void DeleteCourse(Guid CourseId);


        bool CourseExist(Guid CourseId);
        bool StudentExist(Guid StudentId);

    }
}
