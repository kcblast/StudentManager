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
   // [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _manager;
        private readonly IMapper _mapper;

        public StudentController(IStudentManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet]
        //[Route("students")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _manager.GetStudentsAsync();
                   // var studentdto = new List<StudentDto>();
                    if (result == null)
                    {
                        return NotFound("Students unavailable");
                    }
                   // return Ok(_mapper.Map<IEnumerable<StudentDto>>(result));
                    return Ok(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("{StudentId}", Name = "GetStudent")]
        public async Task<IActionResult> GetStudentById(Guid StudentId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _manager.GetStudentByIdAsync(StudentId);
                  
                    if (result == null)
                    {
                        return NotFound("Student not found");
                    }
                    return Ok(_mapper.Map<StudentDto>(result));
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{StudentId}")]
        public async Task<IActionResult> DeleteStudent(Guid StudentId)
        {
            try
            {
                var result = await _manager.GetStudentByIdAsync(StudentId);
                if (ModelState.IsValid)
                {
                    await _manager.DeleteStudentAsync(StudentId);
                    return NoContent();
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<StudentDto>> RegisterStudentAsync(RegisterStudentDto student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _manager.IsStudentExistAsync(student.MatricNumber))
                    {
                        return BadRequest("Student Already Exist");
                    }

                    var studentEntities = _mapper.Map<Student>(student);
                    await _manager.RegisterStudentAsync(studentEntities);

                    var studentToReturn = _mapper.Map<StudentDto>(studentEntities);
                    return CreatedAtRoute("GetStudent", new { StudentId = studentToReturn.StudentId }, studentToReturn);


                    //_manager.RegisterStudent(stud);
                    //return CreatedAtRoute("GetStudentById", new { student.StudentId }, student);
                }
                else
                {
                    return BadRequest("Student Already Exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
