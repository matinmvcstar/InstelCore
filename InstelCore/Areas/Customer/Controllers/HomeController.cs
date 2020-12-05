using InstelCore.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace InstelCore.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [Route("ارتباط_با_ما")]
        public IActionResult Contact(string value)
        {
            if (value == null)
            {
                ViewData["Message"] = "ارسال پیام";
            }
            else
            {
                ViewData["Message"] = value;
            }
            return View();
        }

        [HttpPost]
        [Route("ارتباط_با_ما")]
        public async Task<IActionResult> Contact(MailRequest model)
        {
            if (ModelState.IsValid)
            {
                //var message = new MimeMessage();
                var mm = new MailMessage("bluerosima@gmail.com", model.To);
                mm.Subject = model.Subject;
                mm.Body =
                    "From:" + model.Subject + "<br/>" +
                    "Contact Information: " + model.FullName + "<br/>" +
                    "Message: " + model.Body;
                mm.SubjectEncoding = System.Text.Encoding.UTF8;
                mm.BodyEncoding = System.Text.Encoding.UTF8;
                mm.IsBodyHtml = true;
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587);
                    client.Authenticate("bluerosima@gmail.com", "innbbcmvcmma123");
                    try
                    {             
                        await client.SendAsync((MimeMessage)mm);
                        await client.DisconnectAsync(true);
                        //ViewData["Message"] = "Email send.";
                        return RedirectToAction(nameof(Contact),new { value = "ایمیل ارسال شد" });
                    }
                    catch (Exception)
                    {
                        ViewData["Message"] = "ارسال ایمیل ناموفق می  باشد، مجددا تلاش نمایید";
                    }
                }
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
