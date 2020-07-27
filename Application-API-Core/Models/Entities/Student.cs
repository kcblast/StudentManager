using System;
using System.Collections.Generic;
using System.Text;

namespace Application_API_Core.Models.Entities
{
   public class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MatricNumber { get; set; }
        public string StudentLevel { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
