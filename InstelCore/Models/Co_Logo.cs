using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Models
{
    public class Co_Logo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "آدرس تصویر")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "یک عکس انتخاب کنید")]
        public string LogoPNG { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateTime { get; set; }

        [Display(Name = "نمایش یا عدم نمایش تصویر")]
        [DataType(DataType.ImageUrl)]
        public bool Active { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
    }
}
