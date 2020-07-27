using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application_API_Core.Models.Entities
{
   public class Course
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public string CourseTeacher { get; set; }
        public DateTime CourseSchudle { get; set; }
        [ForeignKey("StudentId")]
        public Student Students { get; set; }
        public Guid StudentId { get; set; }
    }
}
