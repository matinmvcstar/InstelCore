using InstelCore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Models
{
    public class OrderItemVM
    {
        public int Id { get; set; }

        public ProductVM Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public OrderVM Order { get; set; }
    }
}
