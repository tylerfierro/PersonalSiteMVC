using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using PersonalSiteMVC.Models;

namespace StoreFront.Controllers
{
    public class StronglyTypedDataController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }

            string emailBody = $"You have received an email from {cvm.Name} with a subject {cvm.Subject}. Please respond to {cvm.Email} with your response to the following message: <br /> <br />{cvm.Message}";

            MailMessage msg = new MailMessage(
                "no-reply@tylerfierro.net",
                "tmfierro@outlook.com",
                "Email from tylerfierro.net",
                emailBody
                );

            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            msg.CC.Add("tmfierro@outlook.com");
            msg.CC.Add("domainname@gmail.com");

            SmtpClient client = new SmtpClient("mail.tylerfierro.net");
            client.Credentials = new NetworkCredential("no-reply@tylerfierro.net", "Grapes123!");

            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Sorry, something went wrong. Error message: {ex.Message}<br />{ex.StackTrace}";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }
    }
}