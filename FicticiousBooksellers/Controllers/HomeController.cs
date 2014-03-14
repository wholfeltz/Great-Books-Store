using FicticiousBooksellers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FicticiousBooksellers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel model)
        {
            var fromAddress = "ficticiousbooksellers@gmail.com";

            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress, "fiction1234")
            })
            {
                using (var message = new MailMessage(fromAddress, fromAddress)
                {
                    Subject = model.Subject,
                    Body = model.Email + " sent you the following message:\n\n" + model.Message
                })
                {
                    smtp.Send(message);
                }
            }
            return RedirectToAction("Index");

        }
    }
}