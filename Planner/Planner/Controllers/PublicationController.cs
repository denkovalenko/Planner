using Domain;
using Domain.Models;
using Planner.Models;
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
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return View(db.Publications.ToList());

            }
        }

		public ActionResult Create()
		{
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return View(new CreatePublicationViewModel
                {
                    ScientificBases = db.ScientificBases.ToList()
                });

            }

		}

		[HttpPost]
		public ActionResult Create(Publication model)
		{
            using (ApplicationDbContext db = new ApplicationDbContext() )
            {
                Publication publication = new Publication()
                {
                    Name = model.Name,
                    Pages = model.Pages,
                    Text = model.Text,
                    //PublicationAccessoryId = model.PublicationAccessoryId == null ? PublicationsAccessoryEnum.Lecter.ToString() : model.PublicationAccessoryId,
                    //PublicationFeatureId = model.PublicationFeatureId == null ? PublicationsFeatureEnum.Lecter.ToString() : model.PublicationFeatureId,
                    //PublicationTypeId = model.PublicationTypeId == null ? PublicationsTypeEnum.Lecter.ToString() : model.PublicationTypeId
                };
                //PublicationUser pu = new PublicationUser()
                //{
                //    MainAuthor = true,
                //    Publication = publication,
                //    User = new ApplicationDbContext().Users.Where(x=> x.UserName == User.Identity.Name).FirstOrDefault()
                //};
                //publication.PublicationUsers = new List<PublicationUser>();
                //publication.PublicationUsers.Add(pu);
                db.Publications.Add(publication);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
		}
    }
}