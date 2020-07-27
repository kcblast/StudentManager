using Application_API_Core.Interfaces;
using Application_API_Core.Models.Entities;
using Application_API_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application_API_Domain
{
  
    public class StudentManager : IStudentManager
    {
        private readonly ApplicationDbContext _context;
        public StudentManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public void DeleteStudent(Guid StudentId)
        {
            try
            {
                var stud = _context.Students.Find(StudentId);
               
                _context.Remove(stud);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Student GetStudentById(Guid StudentId)
        {
            try
            {
                var stud = _context.Students.FirstOrDefault(a => a.StudentId == StudentId);
                if (stud == null)
                {
                    throw new ArgumentNullException("Student doesn't exist");
                }
                return stud ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            try
            {
                var stud = _context.Students.ToList();
                if (stud == null)
                {
                    return null;
                }

                return stud;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void RegisterStudent(Student student)
        {
            try
            {
                //bool StudentExist = IsStudentExist(matricNumber);
                
                    var stud = new Student
                    {
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        MatricNumber = student.MatricNumber,
                        StudentLevel = student.StudentLevel,

                    };
                    _context.Students.Add(stud);
                
                
                _context.SaveChanges();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateStudent(Guid StudentId, Student student)
        {
            try
            {
                var stud = _context.Students.FirstOrDefault(a => a.StudentId == StudentId);

                if(stud == null)
                {
                    throw new ArgumentNullException("Student doesn't exist");
                }
                _context.Students.Add(stud);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsStudentExist(string matricNumber)
        {

       
            try
            {
                if(_context.Students.Any(a => a.MatricNumber == matricNumber ))
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
