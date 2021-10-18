using PoshakBioSciences.DbModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PoshakBioSciences.Controllers
{
    public class HomeController : Controller
    {
        private PoshBioSolDbEntities db = new PoshBioSolDbEntities();


        public async Task<ActionResult> Index()
        {
            return View(await db.M_ProductMaster.OrderByDescending(x =>x.ProductId).ToListAsync());
            //return View();
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
        [ActionName("Contact")]
        public ActionResult Contact_post(FormCollection obj)
        {
            if (string.IsNullOrEmpty(obj["txtname"].ToString()))
            {
                ViewBag.Status = "Please Enter User Name.";
                return View();
            }
            if (string.IsNullOrEmpty(obj["txtmobile"].ToString()))
            {
                ViewBag.Status = "Please Enter Contact No.";
                return View();
            }
            if (string.IsNullOrEmpty(obj["txtemail"].ToString()))
            {
                ViewBag.Status = "Please Enter EmailID.";
                return View();
            }

            if (string.IsNullOrEmpty(obj["txtSubject"].ToString()))
            {
                ViewBag.Status = "Please Enter Enquiry Subject.";
                return View();
            }

            if (string.IsNullOrEmpty(obj["txtmessage"].ToString()))
            {
                ViewBag.Status = "Please Enter EMail Body.";
                return View();
            }

            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(obj["txtemail"].ToString());
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                message.From = new System.Net.Mail.MailAddress("info@poshakbiosciences.com", "Poshak BioSciences Enquiry");
                message.Bcc.Add("Amitetax@gmail.com");
                message.Bcc.Add("poshakbiosciences@gmail.com");
                message.Subject = " Poshak BioSciences Enquiry Details : " + obj["txtSubject"].ToString();
                message.Body = "Hi " + obj["txtname"].ToString() + ", " + System.Environment.NewLine + System.Environment.NewLine
                    + "======================================================================================== " + System.Environment.NewLine
                    + "  Name : " + obj["txtname"].ToString() + System.Environment.NewLine
                    + "  Contact No : " + obj["txtmobile"].ToString() + System.Environment.NewLine
                    + "  Email ID : " + obj["txtemail"].ToString() + System.Environment.NewLine
                    + "  Subject : " + obj["txtSubject"].ToString() + System.Environment.NewLine
                    + "  Description : " + obj["txtmessage"].ToString() + System.Environment.NewLine
                    + " ======================================================================================== "
                    + System.Environment.NewLine + System.Environment.NewLine
                    + System.Environment.NewLine
                    + System.Environment.NewLine
                    + "Thanks & Regards," + System.Environment.NewLine
                   + "Poshak BioSciences Pvt. Ltd.," + System.Environment.NewLine
                   + "info@poshakbiosciences.com/Amitetax@gmail.com" + System.Environment.NewLine;
                   
                message.IsBodyHtml = false;
                SmtpClient client = new SmtpClient();
                client.Host = "mail.poshakbiosciences.com";
                client.Port = 25;
                client.Credentials = new System.Net.NetworkCredential("info@poshakbiosciences.com", "Admin#123");
                client.Send(message);
                ViewBag.Status = "Mail send Successfully";
                ModelState.Clear();
            }
            catch (Exception ex)
            {
                ViewBag.Status = "Problem while sending email, Please check details." + ex.ToString();
            }
            return View("Contact");
        }

public async Task<ActionResult> Product()
        {
            return View(await db.M_ProductMaster.ToListAsync());
        }
    }
}