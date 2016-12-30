using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DiplomskiCore1.ViewModels;
using System;
using SendGrid;
using System.Net.Mail;
using System.Net;

namespace DiplomskiCore1.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        // POST: Contact/Sendmail
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SendMail(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    //var message = new MimeMessage();  // problem from address is rewrireten white my authentication address which is wrong try to use sendGrid.NetCore
                    //message.From.Add(new MailboxAddress(model.Name, model.Email));
                    //message.To.Add(new MailboxAddress("Nikola Bojkovic", "nikolabojkovic@gmail.com"));
                    //message.Subject = model.Subject;
                    //message.Body = new TextPart("plain")
                    //{
                    //    Text = model.Message
                    //};

                    //using (var client = new SmtpClient())
                    //{
                    //    client.Connect("Smtp.gmail.com", 587);
                    //    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    //    client.Authenticate("nikolabojkovic@gmail.com", "yourPassword");
                    //    client.Send(message);
                    //    client.Disconnect(true);
                    //}


                    var message = new SendGridMessage();
                    message.From = new MailAddress(model.Email, model.Name);
                    message.AddTo("nikolabojkovic@gmail.com");
                    message.Subject = model.Subject;
                    message.Text = model.Message;

                    var credentials = new NetworkCredential("azure_cbaddb14998b0f70fba95fa7171191cb@azure.com", "gaim5867");
                    var transportWeb = new Web(credentials);
                    transportWeb.DeliverAsync(message);

                    model = new ContactViewModel(); // problem view does not refresh model when it bind to element
                    model.Name = "peder";
                    model.MessageSent = true;
                    model.SendMessageResponse = "Message has been sent successfully!";
                    return View("Index", model);
                }
                catch (Exception excep)
                {
                    return RedirectToAction("Index");
                }
            }

            model.MessageSent = false;
            return View("Index", model);
        }
    }
}