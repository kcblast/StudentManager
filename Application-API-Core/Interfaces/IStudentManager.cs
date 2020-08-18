using Application_API_Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application_API_Core.Interfaces
{
   public interface IStudentManager
    {
        Task<object> GetStudentsAsync();
       // Student GetStudentById (Guid StudentId);
        Task<object> GetStudentByIdAsync(Guid StudentId);
        Task RegisterStudentAsync (Student student);
        Task UpdateStudentAsync (Guid StudentId, Student student);
        Task DeleteStudentAsync (Guid StudentId);
        Task<bool> IsStudentExistAsync(string matricNumber);
      


    }
}
