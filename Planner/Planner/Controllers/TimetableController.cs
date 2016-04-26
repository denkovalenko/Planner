using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class TimetableController : Controller
    {
        // GET: Timetable
        public ActionResult Index()
        {
            return View();
        }
    }
}