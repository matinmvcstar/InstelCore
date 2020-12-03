using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Data
{
    public class CoLogo
    {
        [Key]
        public int Id { get; set; }

        public string Image { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Tell { get; set; }
    }
}
