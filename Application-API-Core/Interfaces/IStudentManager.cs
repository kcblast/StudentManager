using Application_API_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_API_Core.Interfaces
{
   public interface IStudentManager
    {
        IEnumerable<Student> GetStudents ();
        Student GetStudentById (Guid StudentId);
        void RegisterStudent (Student student);
        void UpdateStudent (Guid StudentId, Student student);
        void DeleteStudent (Guid StudentId);
        bool IsStudentExist(string matricNumber);
      


    }
}
