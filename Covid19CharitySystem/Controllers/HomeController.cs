using Covid19CharitySystem.BL;
using Covid19CharitySystem.DAL;
using Covid19CharitySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid19CharitySystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // User Login
        public ActionResult Login(string msg)
        {
            ViewBag.msg = msg;
            return View();
        }

        // User Logout
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        //Login Verification
        [HttpPost]
        public ActionResult PostLogin(string email, string password)
        {
            User sp = new UserDAL().Login(email, password);
            if (sp != null && sp.Role == 1)
            {
                Session["AdminId"] = sp.Id;
                Session["Name"] = sp.Name;
                Session["Role"] = sp.Role;
                return RedirectToAction("Index","Admin");
            }
            else if (sp != null && sp.Role == 2)
            {
                Session["DonorId"] = sp.Id;
                Session["Name"] = sp.Name;
                Session["Role"] = sp.Role;
                return RedirectToAction("Index", "Donor");
            }
            else if(sp != null && sp.Role == 3)
            {
                Session["volunteerId"] = sp.Id;
                Session["Name"] = sp.Name;
                Session["Role"] = sp.Role;
                return RedirectToAction("Index", "Volunteer");
            }
            return RedirectToAction("Login", new { msg = "Invalid email or password." });
        }
        public ActionResult  SignUp(string msg)
        {
            ViewBag.Message = msg;

            return View();
        }
        [HttpPost]
        public ActionResult PostSignUp(User obj)
        {
            int temp = new UserBL().AddUser(obj);
            if (temp==1)
            {
                Session["Name"] = obj.Name;
                Session["Role"] = obj.Role;
                return RedirectToAction("Index", "Donor");
            }
            else if (temp==-1)
            {
                return RedirectToAction("SignUp", new { msg = "Email already exists, please try another one." });
            }
            return RedirectToAction("SignUp", new { msg = "Please fill all fields carefully." });
        }

        public ActionResult VolunteerSignUp(string msg)
        {
            ViewBag.Message = msg;

            return View();
        }
        [HttpPost]
        public ActionResult VolunteerPostSignUp(User obj)
        {
            int temp = new UserBL().AddUser(obj);
            if (temp == 1)
            {
                Session["Name"] = obj.Name;
                Session["Role"] = obj.Role;
                return RedirectToAction("Index", "Donor");
            }
            else if (temp == -1)
            {
                return RedirectToAction("VolunteerSignUp", new { msg = "Email already exists, please try another one." });
            }
            return RedirectToAction("VolunteerSignUp", new { msg = "Please fill all fields carefully." });
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}