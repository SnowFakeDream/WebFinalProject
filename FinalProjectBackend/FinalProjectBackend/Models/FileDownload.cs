using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class FileDownload
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalDescription { get; set; }
        public int? AnimalCount { get; set; }
        
    }
}
