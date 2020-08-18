using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application_API_Core.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SchoolManagementUI.Helper;

namespace SchoolManagementUI.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApiRequestUri _apiRequestUri;
        private readonly IHttpContextAccessor _HttpContext;


        public StudentsController(IOptionsSnapshot<ApiRequestUri> options, IHttpContextAccessor _httpContext)
        {
            _apiRequestUri = options.Value;
            _HttpContext = _httpContext;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[Route("Students")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                StudentDto studentDto = new StudentDto();
                if (this.ModelState.IsValid)
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri(_apiRequestUri.BaseUri);
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        // var uri = string.Format(_apiRequestUri.GetStudentById, "2", "name");
                        //api/Student/2/name
                        var uri = _apiRequestUri.BaseUri + _apiRequestUri.GetStudents;

                        HttpResponseMessage res = await httpClient.GetAsync(uri);

                        if (res.IsSuccessStatusCode)
                        {
                            var apiTask = res.Content.ReadAsStringAsync();
                            var responseString = apiTask.Result;
                            var model = JsonConvert.DeserializeObject<StudentListDto>(responseString);

                            return View(model);
                        }
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }
        [HttpGet]
        [Route("/[controller]/{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            try
            {
                StudentDto studentDto = new StudentDto();
                if (this.ModelState.IsValid)
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri(_apiRequestUri.BaseUri);
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        //var uri = string.Format(_apiRequestUri.BaseUri + _apiRequestUri.GetStudentById, id);
                        var uri = string.Format(_apiRequestUri.GetStudentById, id);

                        HttpResponseMessage res = await httpClient.GetAsync(uri);
                        if (res.IsSuccessStatusCode)
                        {
                            var apiTask = res.Content.ReadAsStringAsync();
                            var responseString = apiTask.Result;
                            var model = JsonConvert.DeserializeObject<StudentDto>(responseString);
                            return View(model);
                        }
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult RegisterStudentAsync()
        {
            return View();
        }

        [HttpPost]
        //[Route(")]
        public async Task<ActionResult<StudentDto>> RegisterStudentAsync(RegisterStudentDto register)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    using (var httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = new Uri(_apiRequestUri.BaseUri);
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var student = new RegisterStudentDto()
                        {

                            FirstName = register.FirstName,
                            LastName = register.LastName,
                            MatricNumber = register.MatricNumber,
                            StudentLevel = register.StudentLevel
                        };
                        //var uri = string.Format(_apiRequestUri.BaseUri + _apiRequestUri.GetStudentById, id);
                        var uri = string.Format(_apiRequestUri.AddStudent,register);
                       //var StringContent = new StringContent(JsonConvert.SerializeObject(register));
                        StringContent content = new StringContent(JsonConvert.SerializeObject(register));

                        HttpResponseMessage response = await httpClient.PostAsync(uri, content);

                        //response = await httpClient.PostAsync(uri, register);
                        if (response.IsSuccessStatusCode)
                        {
                            
                            return View("RegisterStudentAsync");
                        }
                        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                        {
                            ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var Register = new RegisterStudentDto();
            return View(Register);
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterStudentDto register)
        {

            try
            {
                if(!ModelState.IsValid)
                {
                    return View(register);
                }

                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_apiRequestUri.BaseUri);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var student = new RegisterStudentDto()
                    {

                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        MatricNumber = register.MatricNumber,
                        StudentLevel = register.StudentLevel
                    };
                    //var uri = string.Format(_apiRequestUri.BaseUri + _apiRequestUri.GetStudentById, id);
                    var uri = string.Format(_apiRequestUri.AddStudent, student);
                    //var StringContent = new StringContent(JsonConvert.SerializeObject(register));
                    StringContent content = new StringContent(JsonConvert.SerializeObject(register));

                    //HttpResponseMessage response = await httpClient.PostAsync(uri, content);
                    HttpResponseMessage response = (HttpResponseMessage)null;
                    
                    response = await httpClient.PostAsJsonAsync(uri, register);
                    if (response.IsSuccessStatusCode)
                    {

                        return View();
                            
                    }
                    if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return View();
        }



    }

}
//if (HttpContext.Request.QueryString.HasValue)
//{
//    uri = $"{uri}{HttpContext.Request.QueryString.ToString()}";
//}