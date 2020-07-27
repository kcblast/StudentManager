using System;
using System.Collections.Generic;
using System.Text;

namespace Application_API_Core.ViewModels
{
   public class CourseDto
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public string CourseTeacher { get; set; }
        public DateTime CourseSchudle { get; set; }
        public Guid StudentId { get; set; }
    }
}
