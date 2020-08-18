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
        public async Task DeleteStudentAsync(Guid StudentId)
        {
            try
            {
                var stud = await _context.Students.FindAsync(StudentId);
               
                 _context.Remove(stud);
               await _context.SaveChangesAsync();
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

        public async Task RegisterStudentAsync(Student student)
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
                
                
               await _context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateStudentAsync(Guid StudentId, Student student)
        {
            try
            {
                var stud = await _context.Students.FirstOrDefaultAsync(a => a.StudentId == StudentId);

                if(stud == null)
                {
                    throw new ArgumentNullException("Student doesn't exist");
                }
                _context.Students.Add(stud);
               await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IsStudentExistAsync(string matricNumber)
        {

       
            try
            {
                if( await _context.Students.AnyAsync(a => a.MatricNumber == matricNumber ))
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


       

       
    }
}
