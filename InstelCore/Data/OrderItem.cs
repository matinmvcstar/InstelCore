using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InstelCore.Data
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public Order Order { get; set; }
    }
}
