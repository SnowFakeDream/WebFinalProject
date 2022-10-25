using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace FinalProjectBackend.Models
{
    public class FileChange
    {

        public string AnimalName { get; set; }
        public string AnimalDescription { get; set; }
        public int? AnimalCount { get; set; }
        public IFormFile AnimalImage { get; set; }
    }
}
