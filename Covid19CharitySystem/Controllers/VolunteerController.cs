using Covid19CharitySystem.BL;
using Covid19CharitySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covid19CharitySystem.Controllers
{
    public class VolunteerController : Controller
    {
        // GET: Volunteer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TaskList()
        {
            int id = Convert.ToInt32(Session["volunteerId"]);
            List<Task> list = new UserBL().getTaskList().Where(x => x.User_Id == id).ToList();
            return View(list);
            
        }
    }
}