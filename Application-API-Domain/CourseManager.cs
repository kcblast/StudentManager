using Application_API_Core.Interfaces;
using Application_API_Core.Models.Entities;
using Application_API_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application_API_Domain
{
    public class CourseManager : ICourseManager
    {
        private readonly ApplicationDbContext _context;
        public CourseManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CourseExist(Guid CourseId)
        {
            try
            {
                if (_context.Courses.Any(a => a.CourseId == CourseId))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool StudentExist(Guid studentId)
        {
            try
            {
                if (_context.Courses.Any(a => a.StudentId == studentId))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCourse(Guid CourseId)
        {
            try
            {
                var del = _context.Courses.Find(CourseId);

                _context.Remove(del);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Course GetCourseForStudent(Guid StudentId, Guid CourseId)
        {
            //try
            //{
            //    var AllCourse = _context.Courses.SingleOrDefault(a => a.StudentId == StudentId || b => b.)
            //}
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetStudentCourses(Guid StudentId)
        {
            try
            {
                var CourseViewList = new List<Course>();
                var course = _context.Courses.Where(a => a.StudentId == StudentId).ToList();

                foreach (var item in course)
                {
                    var courseView = new Course
                    {
                        CourseId = item.CourseId,
                        CourseCode = item.CourseCode,
                        CourseTitle = item.CourseTitle,
                        CourseTeacher = item.CourseTeacher,
                        CourseSchudle = item.CourseSchudle,
                        StudentId = item.StudentId
                    };
                    CourseViewList.Add(courseView);
                }


                return CourseViewList;

           
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RegisterCourse(Guid StudentId, Course course)
        {
            try
            {
                if (StudentId == Guid.Empty)
                    throw new ArgumentNullException();

                if (course == null)
                    throw new ArgumentNullException();

                course.StudentId = StudentId;
                _context.Courses.Add(course);
                _context.SaveChanges();
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Course> GetCourses()
        {
            
            try
            {
                var course = _context.Courses.ToList();
                if (course == null)
                {
                    return null;
                }

                return course;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Course> GetCourse(Guid StudentId)
        {
            throw new NotImplementedException();
            //try
            //{
            //    var course = _context.Courses.Find()
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
    }
}
