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
            if (Session["AdminId"]==null)
            {
                return RedirectToAction("Login","Home");
            }
            ViewBag.volunteers = new UserBL().getUserList().Where(x => x.Role == 3).Count();
            ViewBag.donors = new UserBL().getUserList().Where(x => x.Role == 2).Count();
            ViewBag.donations = new UserBL().getDonationList().Count();
            return View();
        }
        public ActionResult Volunteers()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            List<User> volunteers = new UserDAL().getUsersList().Where(x => x.Role == 3).ToList();
            return View(volunteers);
        }
        public ActionResult Donors()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            List<User> donors = new UserDAL().getUsersList().Where(x => x.Role == 2).ToList();

            return View(donors);
        }
        public ActionResult RecentDonations()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Donation> list = new UserDAL().getDonationsList().Where(x => x.IsAssigned == 0).ToList();
            return View(list);
        }
        public ActionResult CollectedDonations()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Donation> list = new UserDAL().getDonationsList().Where(x => x.IsAssigned !=0).ToList();
            return View(list);
        }
        public ActionResult AssignTask(int Did,string Dtype,string Dloc)
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.donationId = Did;
            ViewBag.donationType = Dtype;
            ViewBag.donationLoc = Dloc;
            ViewBag.volunteers = new UserBL().getUserList().Where(x => x.Role == 3).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult PostTask(Task obj)
        {
            bool temp = new UserBL().AddTask(obj);
            if (temp)
            {
                User vol = new UserBL().getUserById(obj.User_Id);
               
                Donation don = new UserBL().getDonationById(obj.Donation_Id);
                string note = obj.Note == "" ? "Nothing to say." : obj.Note;
                sendEmail(vol.Email,don.Type,don.PickLocation,note);
                Donation donate = new Donation()
                {
                    Id = don.Id,
                    CreatedAt = don.CreatedAt,
                    IsAssigned = obj.User_Id,
                    PickLocation = don.PickLocation,
                    Type = don.Type,
                    User_Id = don.User_Id,
                    Status = 0
                };
                new UserBL().UpdateDonation(donate);
            }
            return RedirectToAction("RecentDonations");
        }

        public JsonResult BlockUser(int id,int status)
        {
            User user = new UserBL().getUserById(id);
            User _user = new User()
            {
                Address = user.Address,
                CreatedAt = user.CreatedAt,
                Email = user.Email,
                Id = user.Id,
                IsActive = status,
                Name = user.Name,
                Password = user.Password,
                Phone = user.Phone,
                Role = user.Role
            };

            bool temp = new UserBL().UpdateUser(_user);
            if (temp)
                return Json(1);
            return Json(-1);
        }
        public bool sendEmail(string email,string type,string loc,string note)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("no-reply@covid19charitysystem.com");
                mail.Subject = "Task Assignment";
                string Body = "<p><html><body>Dear Volunteer! <br /><br />A new task has been assigned to you.<br />Please complete your task as soon as possible.<br /> <b>Donation Type: </b> "+type+"<br/><b>Pick Up Location: </b>"+loc+"<br/><b>Note:</b><br/>"+note+"<br/>Thanks<br /> Team Covid19CharitySystem </body></html></p>";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
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