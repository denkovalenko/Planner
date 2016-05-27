using Calculation;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

		public JsonResult Get()
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				var a = db.Schedules.ToList();
				var departms = db.Departments
					.Select(x => new
					{
							Id = x.Id,
							Name = x.Name
					})
					.OrderBy(x => x.Name)
					.ToList();
				return new JsonResult() { Data = departms, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
			}
		}

        public JsonResult Report(string depId)
        {
            var model = PublicationReportBuilder.CreateDeparmentReport(depId);    
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}