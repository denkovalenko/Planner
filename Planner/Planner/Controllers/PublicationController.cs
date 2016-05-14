using Domain;
using Domain.Models;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
					ScientificBases = db.ScientificBases.ToList(),
					Collaborators = db.PublicationUsers
							.Join(db.Users, pu => pu.UserId, u => u.Id, (pu, u) => new { pu, u })
							.Join(db.ExternalCollaborators, puu => puu.pu.CollaboratorId, c => c.Id, (puu, c) => new { puu, c })
							.AsEnumerable()
							.Select(puuuc => new Author()
							{
								UserId = puuuc.puu.pu.UserId,
								CollaboratorId = puuuc.puu.pu.CollaboratorId,
								Name = puuuc.puu.pu.UserId != null 
										? $"{puuuc.puu.u.FirstName} {puuuc.puu.u.LastName} {puuuc.puu.u.ThirdName}" 
										: puuuc.c.Name
							}).ToList()
                });

            }

		}

		[HttpPost]
		public ActionResult Create(Publication model, HttpPostedFileBase file)
		{
            using (ApplicationDbContext db = new ApplicationDbContext() )
            {
				var user = db.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);
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