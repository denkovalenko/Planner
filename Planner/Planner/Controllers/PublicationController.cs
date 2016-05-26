using Domain.Helpers;
using Domain.Models;
using Domain.Models.Enums;
using Domain.Reports;
using Planner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Calculation;
using System.IO;

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
			return View(PublicationReportBuilder.CreateForm11(user));
		}

		public ActionResult Create()
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				var model = new CreatePublicationViewModel
				{
					NMDBs = db.NMBDs.ToList(),
				};

				return View(model);

			}

		}

		[HttpPost]
		public ActionResult Create(PublicationCreate model, HttpPostedFileBase file)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				var filepath = ConfigurationManager.AppSettings["PublicationFolder"] + new Random().Next() + file.FileName.Substring(file.FileName.LastIndexOf('.'));
				try
				{

					var a = Server.MapPath(filepath);
					file.SaveAs(Server.MapPath(filepath));

					var allAuthors = model?.NewCollaboratorsNames?.Count + model?.CollaboratorsIds?.Count + 1;

					Publication publication = new Publication()
					{
						Name = model.Name,
						FilePath = filepath,
						Output = model.Output,
						Pages = model.Pages,
						StoringType = new StoringType() { Value = model.StoringType },
						PublicationType = new PublicationType() { Value = model.PublicationType },
						CreatedAt = DateTime.Now.ToUniversalTime(),
						PublishedAt = DateTime.Now.ToUniversalTime(),
						IsPublished = true,
						IsOverseas = model.IsOverseas,
						OwnerId = user.Id,
						CitationNumberNMBD = model.CitationNumberNMBD,
						ImpactFactorNMBD = model.ImpactFactorNMBD,
						ResearchDoneType = new ResearchDoneType() { Value = model.ResearchDoneType},
						PublicationNMBDs = new List<PublicationNMBD>()
						{
							new PublicationNMBD()
							{
								NMBDId = model.NMBDId
							}
						},
						PublicationUsers = new List<PublicationUser>
						{
							new PublicationUser()
							{
								UserId = user.Id,
								PageQuantity = model.Pages / allAuthors.Value
							}
						}
					};
					if (model.CollaboratorsIds != null)
					{
						foreach (var collab in model.CollaboratorsIds.Where(x => x != String.Empty && x.Substring(0, 2) == "c_"))
						{
							publication.PublicationUsers.Add(new PublicationUser()
							{
								CollaboratorId = collab.Substring(2),
								Publication = publication,
								PageQuantity = model.Pages / allAuthors.Value
							});
						}
						foreach (var collab in model.CollaboratorsIds.Where(x => x != String.Empty && x.Substring(0, 2) == "u_"))
						{
							publication.PublicationUsers.Add(new PublicationUser()
							{
								UserId = collab.Substring(2),
								Publication = publication,
								PageQuantity = model.Pages / allAuthors.Value
							});
						}
					}
					if (model.NewCollaboratorsNames != null)
					{
						foreach (var collab in model.NewCollaboratorsNames.Where(x => x != String.Empty))
						{
							var newcollab = new ExternalCollaborator() { Name = collab };
							db.ExternalCollaborators.Add(newcollab);
							publication.PublicationUsers.Add(new PublicationUser()
							{
								Collaborator = newcollab,
								Publication = publication,
								PageQuantity = model.Pages / allAuthors.Value
							});
						}
					}


					db.Publications.Add(publication);
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					System.IO.File.Delete(filepath);
				}

				return RedirectToAction("Index");
			}
		}

		public FileResult PrintForm11()
		{
			var filestream = PublicationReportBuilder.ReportForm11(user);
			
			return File(filestream, "application/vnd.ms-excel", $"Публикации {user.LastName} {user.FirstName.Substring(0, 1)}. {user.ThirdName.Substring(0, 1)}. - {DateTime.Now.ToShortDateString()}.xls");
				
							
		}
	}
}