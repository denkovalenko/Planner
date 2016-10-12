using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Models;

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
            var a = new PlanTrainingJob()
            {
                CountStudent = 4,
                Course = 3
            };
            var list = new List<PlanTrainingJob> {a};

            return View("Test",list);

        }
    }
}