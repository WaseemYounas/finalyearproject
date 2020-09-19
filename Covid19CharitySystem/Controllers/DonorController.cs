using Covid19CharitySystem.BL;
using Covid19CharitySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid19CharitySystem.Controllers
{
    public class DonorController : Controller
    {
        // GET: Donor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            Session["Name"] = null;
            return RedirectToAction("Index","Home");
        }
        public ActionResult AddDonation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostDonation(Donation donate)
        {
            donate.User_Id = Convert.ToInt32(Session["DonorId"]);
            bool temp = new UserBL().AddDonation(donate);
            return RedirectToAction("PreviousDonations");
        }
        public ActionResult PreviousDonations()
        {
            List<Donation> list = new UserBL().getDonationList();
            return View(list);
        }
    }
}