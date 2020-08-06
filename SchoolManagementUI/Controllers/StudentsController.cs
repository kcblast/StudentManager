using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                            var apiTask =  res.Content.ReadAsStringAsync();
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
        public async Task<IActionResult> GetStudentById (Guid id)
        {
            try
            {
                StudentDto studentDto = new StudentDto();
                if(this.ModelState.IsValid)
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
    }
}
//if (HttpContext.Request.QueryString.HasValue)
//{
//    uri = $"{uri}{HttpContext.Request.QueryString.ToString()}";
//}