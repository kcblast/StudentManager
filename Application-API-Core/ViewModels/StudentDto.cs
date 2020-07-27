using System;
using System.Collections.Generic;
using System.Text;

namespace Application_API_Core.ViewModels
{
   public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MatricNumber { get; set; }
        public string StudentLevel { get; set; }
    }
}
