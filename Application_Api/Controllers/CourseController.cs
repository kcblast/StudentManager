using Application_API_Core.Interfaces;
using Application_API_Core.Models.Entities;
using Application_API_Core.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseManager _manager;
        private readonly IMapper _mapper;
        public CourseController(ICourseManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper; ;
        }

        [HttpGet]
        [Route("{StudentId}", Name = "GetStudentCourse")]
        public ActionResult<IEnumerable<CourseDto>> GetCoursesForStudent (Guid StudentId)
        {
            try
            {
                if (!_manager.StudentExist(StudentId))
                {
                    return NotFound();
                }
                var result = _manager.GetStudentCourses(StudentId);
                return Ok(_mapper.Map<IEnumerable<CourseDto>>(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> Courses ()
        {
            try
            {
                var result = _manager.GetCourses();
                    return Ok(_mapper.Map<IEnumerable<CourseDto>>(result));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("{StudentId}/RegisterCourse")]
        public ActionResult<CourseDto> AddStudentCourse(Guid StudentId, RegisterCourseDto course)
        {
            try
            {
                
                if (_manager.StudentExist(StudentId))
                {
                    return NotFound();
                }
                var courseEntities = _mapper.Map<Course>(course);
                _manager.RegisterCourse(StudentId, courseEntities);

                var courseToReturn = _mapper.Map<CourseDto>(courseEntities);
                return CreatedAtRoute("GetStudentCourse", new 
                { StudentId = StudentId, CourseId = courseToReturn.CourseId}, 
                courseToReturn);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[HttpDelete]
        //[Route("{courseId}/delete")]
        //public IActionResult DeleteCourse(Guid courseId)
        //{
        //    try
        //    {
        //        if (!_manager.CourseExist(courseId))
        //        {
        //            return NotFound();
        //        }
        //        var result = _manager.DeleteCourse

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
