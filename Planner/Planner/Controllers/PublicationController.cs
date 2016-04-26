using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Planner.Controllers
{
    public class PublicationController : Controller
    {
        // GET: Publication
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult Create()
		{
			//using (GenericRepository<ApplicationUser> repo = new GenericRepository<ApplicationUser>(new ApplicationDbContext()))
			//{
			//	return View(repo.GetBy(x => x.Position.Value == PositionEnum.Lecturer).ToList());
				
			//}
			return View();

		}

		[HttpPost]
		public ActionResult Create(Publication model)
		{
			return View();
		}
    }
}