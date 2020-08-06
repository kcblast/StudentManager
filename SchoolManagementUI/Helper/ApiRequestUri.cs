using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementUI.Helper
{
    public class ApiRequestUri
    {
        public string BaseUri { get; set; }
        public string  GetStudents { get; set; }
        public string GetStudentById { get; set; }
        public string AddStudent { get; set; }
        public string GetCourseForStudent { get; set; }
        public string GetCourses { get; set; }
        public string DeleteStudent { get; set; }
        public string DeleteCourse { get; set; }
    }
}
