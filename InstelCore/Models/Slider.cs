using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public DateTime CreateSlide { get; set; }

        public bool Active { get; set; }
    }
}
