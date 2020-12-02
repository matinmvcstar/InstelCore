using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "آدرس تصویر")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "یک عکس انتخاب کنید")]
        public string Image { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "تاریخ ثبت را وارد کنید",AllowEmptyStrings = true)]
        public DateTime CreateSlide { get; set; }

        [Display(Name = "نمایش یا عدم نمایش تصویر")]
        [DataType(DataType.ImageUrl)]
        public bool Active { get; set; }
    }
}
