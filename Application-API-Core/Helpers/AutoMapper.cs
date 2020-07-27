using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_API_Core.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Models.Entities.Student, ViewModels.StudentDto>();
            CreateMap<Models.Entities.Course, ViewModels.CourseDto>();
            CreateMap<ViewModels.RegisterCourseDto, Models.Entities.Course>();
            CreateMap<ViewModels.RegisterStudentDto, Models.Entities.Student>();
        }
    }
}
