using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Image { get; set; }

        public string Header { get; set; }

        public string Text { get; set; }

        public long Price { get; set; }

        public DateTime CreateSlide { get; set; }

        public bool Active { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public string CustomerId { get; set; }
    }
}
