using InstelCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Models
{
    public class OrderItemVM
    {
        public int Id { get; set; }

        public ProductVM Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public OrderVM Order { get; set; }
    }
}
