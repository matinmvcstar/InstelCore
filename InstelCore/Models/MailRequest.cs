using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Models
{
    public class MailRequest
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "ایمیل خود را به درستی وارد کنید")]
        public string To { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "عنوان پیام خود را وارد کنید")]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "متن پیام خود را وارد کنید")]
        public string Body { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "نام و نام خانوادگی خود را وارد کنید")]
        public string FullName { get; set; }

        public IFormFile Attachment { get; set; }
    }
}
