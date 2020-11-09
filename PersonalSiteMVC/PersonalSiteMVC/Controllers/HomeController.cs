using PersonalSiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PersonalSiteMVC.Controllers
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

        public ActionResult Links()
        {
            ViewBag.Message = "My Classmates pages!";

            return View();
        }

        public ActionResult Resume()
        {
            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string body = $"{cvm.Name} has sent you the following message: <br />" + $"{cvm.Message} <strong>from the email address:</strong> {cvm.Email}";
                MailMessage m = new MailMessage("tyler@tylerfierro.net", "tmfierro@outlook.com", cvm.Subject, body);

                m.IsBodyHtml = true;

                m.Priority = MailPriority.High;

                m.ReplyToList.Add(cvm.Email);

                SmtpClient client = new SmtpClient("mail.tylerfierro.net");

                client.Credentials = new NetworkCredential("no-reply@tylerfierro.net", "Grapes123!");

                try
                {
                    client.Send(m);
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.StackTrace;
                    return View(cvm);
                }
                return View("EmailConfirmation", cvm);
            }
            return View(cvm);
        }
    }
}