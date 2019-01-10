using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreClt_WebApiCore.Models;
using System.Net.Http;
using System.IO;

namespace WebAppCoreClt_WebApiCore.Controllers
{
    //https://stackoverflow.com/questions/51798265/how-to-send-iformfile-to-web-api-as-part-of-viewmodel-object
    [Produces("application/json")]
    [Route("api/StudentClt")]
    public class StudentCltController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDetailsViewModel sd)
        {
            HttpClient client = new HttpClient();
            var url = "http://localhost:4069/api/student/15";
            byte[] data;
            using (var br = new BinaryReader(sd.File.OpenReadStream())) 
            {
                data = br.ReadBytes((int)sd.File.OpenReadStream().Length);
                ByteArrayContent bytes = new ByteArrayContent(data);

                MultipartFormDataContent multiContent = new MultipartFormDataContent();
                multiContent.Add(bytes, "file", sd.File.FileName);
                multiContent.Add(new StringContent(sd.Id.ToString()), "Id");
                multiContent.Add(new StringContent(sd.Name.ToString()), "Name");

                var response = await client.PostAsync(url, multiContent);
                bool result = response.IsSuccessStatusCode;
                return View("Index");
            }

        }
    }
}