using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Planner.Controllers
{
    public class TimetableController : Controller
    {
		private ApplicationUser user;
		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				user = db.Users.FirstOrDefault(x => x.UserName == requestContext.HttpContext.User.Identity.Name);
			}

		}
		// GET: Timetable
		public ActionResult Index()
        {
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				
				return View((object)db.Users.FirstOrDefault(u => u.Id == user.Id).TimetableId);
			}
				
        }
    }
}