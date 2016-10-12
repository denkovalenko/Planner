using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class IndividualPlanController : Controller
    {
        // GET: IndividualPlan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TrainingJob()
        {
            return View();
        }
    }
}