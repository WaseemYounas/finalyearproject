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
            if (Session["DonorId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.allDonations = new UserBL().getDonationList().Where(x => x.User_Id == Convert.ToInt32(Session["DonorId"])).Count();
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
            if (Session["DonorId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
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
            if (Session["DonorId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            List<Donation> list = new UserBL().getDonationList();
            return View(list);
        }
        public JsonResult RemoveDonation(int dId)
        {
            bool temp = new UserBL().DeleteDonation(dId);
            if (temp)
                return Json(1);
            return Json(-1);
        }
    }
}