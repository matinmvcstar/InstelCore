using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Models
{
    public class ProductVM
    {
        public int Id { get; set; }

        public string Image { get; set; }

        public string Header { get; set; }

        public string Text { get; set; }

        public long Price { get; set; }

        public DateTime CreateSlide { get; set; }

        public bool Active { get; set; }


        public CategoryVM Category { get; set; }

        public int CategoryId { get; set; }


        public CustomerVM Customer { get; set; }

        public string CustomerId { get; set; }


        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<SelectListItem> Customers { get; set; }
    }
}
