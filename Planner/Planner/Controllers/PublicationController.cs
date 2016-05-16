using Domain;
using Domain.Models;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Planner.Controllers
{
    public class PublicationController : Controller
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
				var users = db.Users
						.AsEnumerable()
						.Select(u => new Author()
						{
							UserId = u.Id,
							CollaboratorId = null,
							Name = $"{u.LastName} {u.FirstName} {u.ThirdName}"
						})
						.OrderBy(x => x.Name).ToList();
				var collaborators = db.ExternalCollaborators
						.AsEnumerable()
						.Select(u => new Author()
						{
							UserId = null,
							CollaboratorId = u.Id,
							Name = u.Name
						})
						.OrderBy(x => x.Name).ToList();
				var model = new CreatePublicationViewModel
				{
					ScientificBases = db.ScientificBases.Reverse().ToList(),
					Collaborators = new List<Author>()
				};
				model.Collaborators.AddRange(users);
				model.Collaborators.AddRange(collaborators);
				return View(model);

            }

		}

		[HttpPost]
		public ActionResult Create(Publication model, HttpPostedFileBase file)
		{
            using (ApplicationDbContext db = new ApplicationDbContext() )
            {
				var filepath = ConfigurationManager.AppSettings["PublicationFolder"] + new Random().Next() + file.FileName.Substring(file.FileName.LastIndexOf('.'));
				var a = Server.MapPath(filepath);
				file.SaveAs(Server.MapPath(filepath));
                Publication publication = new Publication()
                {
                    Name = model.Name,
					FilePath = filepath,
					PublicationUsers = new List<PublicationUser>
					{
						new PublicationUser()
						{
							User = user
						}
					}
                };
                db.Publications.Add(publication);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
		}
    }
}