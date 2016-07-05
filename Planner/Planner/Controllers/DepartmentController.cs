using Calculation;
using Domain.Models;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.Controllers
{
	[Authorize]
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult DepartmentPublications()
        {
            return View();
        }

		public ActionResult HalfYearDepartmentPublications()
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

        public JsonResult DepartmentPublicationsReport(string depId)
        {
            var model = PublicationReportBuilder.CreateDeparmentReport(depId);    
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

		public FileResult PrintDepartmentPublicationsReport(string id, string name)
		{
			var filestream = PublicationReportBuilder.PrintDepartmentReport(id, name);

			return File(filestream, "application/vnd.ms-excel", $"Публикации - {name} - {DateTime.Now.ToShortDateString().Replace('/', '-')}.xls");
		}


		public JsonResult HalfYearDepartmentReport(string depId, int year, int half)
		{
			var model = PublicationReportBuilder.ScientificPublishing(depId, year, half);
			return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}
        public JsonResult DateRangeDepartmentReport(string depId, DateTime start, DateTime end)
        {
            var model = PublicationReportBuilder.CreateDeparmentReport(depId, start, end);
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public FileResult PrintHalfYearDepartmentReport(string depId, int year, int half)
		{
            var model = PublicationReportBuilder.ScientificPublishing(depId, year, half);
            SLDocument doc = PublicationReportBuilder.PrintHalfReport(model);
            var ms = new MemoryStream();
            doc.SaveAs(ms);
            ms.Position = 0;
            var name = "Звiт за пiврiччя-" + DateTime.UtcNow.ToLongDateString() + ".xlsx";
            return File(ms,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name);
		}
	}
}