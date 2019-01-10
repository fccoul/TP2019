﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreClt_WebApiCore.Models
{
    public class StudentDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
