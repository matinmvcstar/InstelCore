using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "آدرس تصویر")]
        [DataType(DataType.ImageUrl)]
        [Required(ErrorMessage = "یک عکس انتخاب کنید")]
        public string Image { get; set; }

        [Display(Name = "عنوان")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "یک عنوان وارد کنید")]
        public string Header { get; set; }

        [Display(Name = "متن")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "متن پیام را وارد کنید")]
        public string Text { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "تاریخ ثبت را وارد کنید", AllowEmptyStrings = true)]
        public DateTime CreateSlide { get; set; }

        [Display(Name = "نمایش یا عدم نمایش پست")]
        [DataType(DataType.ImageUrl)]
        public bool Active { get; set; }

        [ForeignKey("AspNetUsers")]
        public string UserId { get; set; }
    }
}
