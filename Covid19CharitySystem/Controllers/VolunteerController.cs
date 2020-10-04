using Covid19CharitySystem.BL;
using Covid19CharitySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Covid19CharitySystem.Controllers
{
    public class VolunteerController : Controller
    {
        // GET: Volunteer
        public ActionResult Index()
        {
            if (Session["volunteerId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewBag.newtask = new UserBL().getTaskList().Where(x => x.User_Id == Convert.ToInt32(Session["volunteerId"])&&x.Status==0).Count();
            ViewBag.completedtask = new UserBL().getTaskList().Where(x => x.User_Id == Convert.ToInt32(Session["volunteerId"])&&x.Status==1).Count();
            return View();
        }

        public ActionResult TaskList()
        {
            if (Session["volunteerId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int id = Convert.ToInt32(Session["volunteerId"]);
            List<Task> list = new UserBL().getTaskList().Where(x => x.User_Id == id&&x.Status==0).ToList();
            return View(list);

        }
        public ActionResult CompletedTaskList()
        {
            if (Session["volunteerId"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            int id = Convert.ToInt32(Session["volunteerId"]);
            List<Task> list = new UserBL().getTaskList().Where(x => x.User_Id == id && x.Status == 1).ToList();
            return View(list);

        }
        public JsonResult UpdateStatus(int taskId)
        {
            Task task = new UserBL().getTaskById(taskId);
            Task utask = new Task()
            {
                Id = task.Id,
                CreatedAt = task.CreatedAt,
                Note = task.Note,
                Donation_Id = task.Donation_Id,
                IsActive = 1,
                Status = 1,
                User_Id = task.User_Id
            };
           
            bool temp = new UserBL().UpdateTask(utask);
             Donation don = new UserBL().getDonationById(utask.Donation_Id);
            Donation donate = new Donation()
            {
                Id = don.Id,
                CreatedAt = don.CreatedAt,
                IsAssigned =don.IsAssigned,
                PickLocation = don.PickLocation,
                Type = don.Type,
                User_Id = don.User_Id,
                Status = 1
            };
            new UserBL().UpdateDonation(donate);
            if (temp)
                return Json(1);
            return Json(-1);
        }
    }
}