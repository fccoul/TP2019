using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Models;
using System.IO;

namespace WebApiCore.Controllers
{
    //[Produces("application/json")]
    //[Route("api/Student")]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {

        [HttpPost("{refGMF}")]
        //[HttpPost]
        //public async Task<IActionResult> Post(int id, StudentViewModel sd)
        //public async Task<IActionResult> Post(int ?id,StudentViewModel sd)
        public async Task<IActionResult> Post(int refGMF,StudentViewModel sd)
        {
            string path = @"F:\WriteFromCode\log.txt";
            using (var stream = new FileStream(path,FileMode.Create))
            {
                await sd.File.CopyToAsync(stream);
            }
            return Ok();
        }
    }
}