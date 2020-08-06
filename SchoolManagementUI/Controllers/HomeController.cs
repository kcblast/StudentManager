using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application_API_Core.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SchoolManagementUI.Helper;
using SchoolManagementUI.Models;

namespace SchoolManagementUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiRequestUri _apiRequestUri;
        private readonly IHttpContextAccessor _HttpContext;
       // private readonly IHostingEnvironment _appEnvironment;


        public HomeController(ILogger<HomeController> logger, IOptionsSnapshot<ApiRequestUri> options, IHttpContextAccessor _httpContext)
        {
            _logger = logger;
            _apiRequestUri = options.Value;
            _HttpContext = _httpContext;
            //_appEnvironment = appEnvironent;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[HttpGet]
        //[Route("Students")]
        //public async Task<IActionResult> GetAllStudents()
        //{
        //    try
        //    {
        //        StudentDto studentDto = new StudentDto();
        //        if (this.ModelState.IsValid)
        //            using (var httpClient = new HttpClient())
        //            {
        //                httpClient.BaseAddress = new Uri(_apiRequestUri.BaseUri);
        //                httpClient.DefaultRequestHeaders.Accept.Clear();
        //                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //                var uri = _apiRequestUri.BaseUri + _apiRequestUri.GetStudents;
        //                if (HttpContext.Request.QueryString.HasValue)
        //                {
        //                    uri = $"{uri}{HttpContext.Request.QueryString.ToString()}";
        //                }
        //                HttpResponseMessage res = await httpClient.GetAsync(uri);

        //                if (res.IsSuccessStatusCode)
        //                {
        //                    var apiTask = res.Content.ReadAsStringAsync();
        //                    var responseString = apiTask.Result;
        //                    var model = JsonConvert.DeserializeObject<StudentDto>(responseString);

        //                    return View(model);
        //                }
        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return View();
        //}



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
