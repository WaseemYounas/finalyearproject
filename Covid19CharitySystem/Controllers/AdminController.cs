using Covid19CharitySystem.BL;
using Covid19CharitySystem.DAL;
using Covid19CharitySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Covid19CharitySystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Volunteers()
        {
            List<User> volunteers = new UserDAL().getUsersList().Where(x => x.Role == 3).ToList();
            return View(volunteers);
        }
        public ActionResult Donors()
        {
            List<User> donors = new UserDAL().getUsersList().Where(x => x.Role == 2).ToList();

            return View(donors);
        }
        public ActionResult RecentDonations()
        {
            List<Donation> list = new UserDAL().getDonationsList().Where(x => x.Status == 0).ToList();
            return View(list);
        }
        public ActionResult CollectedDonations()
        {
            List<Donation> list = new UserDAL().getDonationsList().Where(x => x.Status == 1).ToList();
            return View(list);
        }
        public ActionResult AssignTask(int Did)
        {
            ViewBag.donationId = Did;
            ViewBag.volunteers = new UserBL().getUserList().Where(x => x.Role == 2).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult PostTask(Task obj)
        {
            bool temp = new UserBL().AddTask(obj);
            if (temp)
            {
                User vol = new UserBL().getUserById(obj.User_Id);
                sendEmail(vol.Email);
                Donation don = new UserBL().getDonationById(obj.Donation_Id);
                Donation donate = new Donation()
                {
                    Id = don.Id,
                    CreatedAt = don.CreatedAt,
                    IsAssigned = obj.User_Id,
                    PickLocation = don.PickLocation,
                    Type = don.Type,
                    User_Id = don.User_Id,
                    Status = 1
                };
                new UserBL().UpdateDonation(donate);
            }
            return RedirectToAction("RecentDonations");
        }
        public bool sendEmail(string email)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("aqsajamil0198@gmail.com");
                mail.Subject = "Task Assignment";
                string Body = "<p><html><body>Dear Volunteer! <br /><br />A new task has been assigned to you.<br />Please complete your task as soon as possible.<br />Thanks<br /> Team Covid19CharitySystem </body></html></p>";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("aqsajamil0198@gmail.com", "aqsa1234"); // Enter seders User name and password   
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}