using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "آدرس تصویر")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "گروه خود را وارد کنید")]
        public string OfferPNG { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
    }
}
