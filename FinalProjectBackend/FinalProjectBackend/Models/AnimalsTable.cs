using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FinalProjectBackend.Models
{
    public partial class AnimalsTable
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalDescription { get; set; }
        public int? AnimalCount { get; set; }
        public string AnimalImage { get; set; }
    }
}
