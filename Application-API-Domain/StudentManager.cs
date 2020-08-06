using Application_API_Core.Interfaces;
using Application_API_Core.Models.Entities;
using Application_API_Core.ViewModels;
using Application_API_Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task <object> GetStudentByIdAsync(Guid StudentId)
        {
            try
            {
                var stud = await _context.Students.FirstOrDefaultAsync(a => a.StudentId == StudentId);
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

        public async Task <object> GetStudentsAsync()
        {
            try
            {
                //var stud = await _context.Students.Include(b => b.Courses).ToListAsync();
                var stud = await _context.Students.ToListAsync();
                if (stud == null)
                {
                    return null;
                }
                var studentList = new StudentListDto
                {
                    Students = stud.ToList()
                };
                return studentList;
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

        //public Task<object> GetStudentByIdAsync(Guid StudentId)
        //{
        //    throw new NotImplementedException();
        //}

        Task IStudentManager.RegisterStudent(Student student)
        {
            throw new NotImplementedException();
        }

        Task IStudentManager.UpdateStudent(Guid StudentId, Student student)
        {
            throw new NotImplementedException();
        }

        Task<bool> IStudentManager.IsStudentExist(string matricNumber)
        {
            throw new NotImplementedException();
        }
    }
}
