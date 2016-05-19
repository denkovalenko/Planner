using Domain;
using Domain.Models;
using Domain.Models.Enums;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                return View(db.Publications
					.Include("StoringType")
					.AsEnumerable()
					.Select(x => new PublicationForm11()
					{
						Id = x.Id,
						FilePath = x.FilePath,
						Name = x.Name,
						Pages = x.Pages,
						StoringType = ((DisplayAttribute)typeof(StoringTypeEnum)
								.GetMember(x.StoringType.Value.ToString())[0]
								.GetCustomAttributes(typeof(DisplayAttribute),false)[0]).Name
					})
					.ToList());
            }
        }

		public ActionResult Create()
		{
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
				//var users = db.Users
				//	.Where(u=> u.Id != user.Id)
				//		.AsEnumerable()
				//		.Select(u => new Author()
				//		{
				//			UserId = "u_"+u.Id,
				//			CollaboratorId = null,
				//			Name = $"{u.LastName} {u.FirstName} {u.ThirdName}"
				//		})
				//		.OrderBy(x => x.Name).ToList();
				//var collaborators = db.ExternalCollaborators
				//		.AsEnumerable()
				//		.Select(u => new Author()
				//		{
				//			UserId = null,
				//			CollaboratorId = "c_"+u.Id,
				//			Name = u.Name
				//		})
				//		.OrderBy(x => x.Name).ToList();
				var model = new CreatePublicationViewModel
				{
					ScientificBases = db.ScientificBases.ToList(),
					//Collaborators = new List<Author>()
				};
				//model.Collaborators.AddRange(users);
				//model.Collaborators.AddRange(collaborators);
				return View(model);

            }

		}

		[HttpPost]
		public ActionResult Create(PublicationCreate model, HttpPostedFileBase file)
		{
            using (ApplicationDbContext db = new ApplicationDbContext() )
            {
				try
				{
					var filepath = ConfigurationManager.AppSettings["PublicationFolder"] + new Random().Next() + file.FileName.Substring(file.FileName.LastIndexOf('.'));
					var a = Server.MapPath(filepath);
					file.SaveAs(Server.MapPath(filepath));
					Publication publication = new Publication()
					{
						Name = model.Name,
						FilePath = filepath,
						Pages = model.Pages,
						StoringType = new StoringType() { Value = model.StoringType },
						PublicationScientificBases = new List<PublicationScientificBase>()
					{
						new PublicationScientificBase()
						{
							ScientificBaseId = model.ScientificBaseId
						}
					},
						PublicationUsers = new List<PublicationUser>
						{
							new PublicationUser()
							{
								UserId = user.Id
							}
						}
					};
					foreach (var collab in model.CollaboratorsIds.Where(x => x != String.Empty && x.Substring(0, 2) == "c_"))
					{
						publication.PublicationUsers.Add(new PublicationUser()
						{
							CollaboratorId = collab.Substring(2),
							Publication = publication
						});
					}
					foreach (var collab in model.CollaboratorsIds.Where(x => x != String.Empty && x.Substring(0, 2) == "u_"))
					{
						publication.PublicationUsers.Add(new PublicationUser()
						{
							UserId = collab.Substring(2),
							Publication = publication
						});
					}
					db.Publications.Add(publication);
					db.SaveChanges();
				}
				catch(Exception ex)
				{

				}
				
                return RedirectToAction("Index");
            } 
		}
    }
}