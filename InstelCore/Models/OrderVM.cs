using InstelCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InstelCore.Models
{
    public class OrderVM
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }

        public ICollection<OrderItemVM> Items { get; set; }
    }
}
