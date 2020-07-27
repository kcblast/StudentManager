using Application_API_Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers

{
         [ApiController]
         [Route("[controller]")]
        public class StudentController : ControllerBase
        {
   
              private readonly IStudentManager _studentManager;

            public StudentController(IStudentManager studentManager)
            {
                _studentManager = studentManager;
            }

            [Route("allstudents")]
            [HttpGet]
            public IActionResult GetStudents()
            {
            try
            {
                var stud = _studentManager.GetStudents();
                if(stud != null)
                {
                    return Ok(stud);
                }
                return NotFound("Student doesn't exist.");
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
                
            }
     
    
        }
}
