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
				var model = new List<PublicationForm11>();
				try
				{
					var query = db.Publications
					.Include("StoringType")
					.Include("PublicationType")
					.AsEnumerable()
					.Where(x => x.IsPublished == true);

					model = query
                        .AsEnumerable()
					.Select(x => new PublicationForm11()
					{
						Id = x.Id,
						FilePath = x.FilePath,
						Name = x.Name,
						Pages = x.Pages.HasValue ? x.Pages.Value : x.Pages.Value,
						Output = x.Output,
						PublishedAt = x.PublishedAt.HasValue ? x.PublishedAt.Value : DateTime.MinValue,
						StoringType =
                        ((DisplayAttribute)typeof(StoringTypeEnum)
                                .GetMember(x.StoringType.Value.ToString())[0]
                                .GetCustomAttributes(typeof(DisplayAttribute), false)[0]).Name,
                        PublicationType =
                        ((DisplayAttribute)typeof(PublicationTypeEnum)
                                .GetMember(x.PublicationType.Value.ToString())[0]
                                .GetCustomAttributes(typeof(DisplayAttribute), false)[0]).Name,
                        Collaborators = new List<Author>()

                    })
					.ToList();
                    //foreach (var pub in model)
                    //{
                    //    var query1 = db.PublicationUsers
                    //        .Where(p => p.PublicationId == pub.Id)
                    //        .Where(u => u.UserId != user.Id)
                    //        .Join(db.Users, pup => pup.UserId, u => u.Id, (pup, u) => new { pup, u })
                    //        .Join(db.ExternalCollaborators, pu => pu.pup.CollaboratorId, c => c.Id, (pu, c) => new { pu, c })
                    //        .ToList();
                    //    var query2 = query1
                    //        .Select(a => new Author()
                    //        {
                    //            UserId = "qweqweqw",
                    //            CollaboratorId = "qweqwe",
                    //            Name = "name"
                    //            //UserId = a.pu.u.Id,
                    //            //CollaboratorId = a.c.Id,
                    //            //Name = a.pu.u.Id != null ? $"{a.pu.u.LastName} {a.pu.u.FirstName} {a.pu.u.ThirdName}"
                    //            //                        : a.c.Name
                    //        })
                    //        .ToList();
                    //    pub.Collaborators.AddRange(query2);
                    //        //db.PublicationUsers
                    //        //.Where(p => p.PublicationId == pub.Id)
                    //        //.Where(u => u.UserId != user.Id)
                    //        //.Join(db.Users, pup => pup.UserId, u => u.Id, (pup, u) => new { pup, u })
                    //        //.Join(db.ExternalCollaborators, pu => pu.pup.CollaboratorId, c => c.Id, (pu, c) => new { pu, c })
                    //        //.AsEnumerable()
                    //        //.Select(a => new Author()
                    //        //{
                    //        //    UserId = "qweqweqw",
                    //        //    CollaboratorId = "qweqwe",
                    //        //    Name = "name"
                    //        //    //UserId = a.pu.u.Id,
                    //        //    //CollaboratorId = a.c.Id,
                    //        //    //Name = a.pu.u.Id != null ? $"{a.pu.u.LastName} {a.pu.u.FirstName} {a.pu.u.ThirdName}"
                    //        //    //                        : a.c.Name
                    //        //})
                    //        //.ToList();
                    //}
                    //model.ForEach(x => x.Collaborators = db.PublicationUsers
                    //        .Where(p => p.PublicationId == x.Id)
                    //        .Where(u => u.UserId != user.Id)
                    //        .Join(db.Users, pup => pup.UserId, u => u.Id, (pup, u) => new { pup, u })
                    //        .Join(db.ExternalCollaborators, pu => pu.pup.CollaboratorId, c => c.Id, (pu, c) => new { pu, c })
                    //        .AsEnumerable()
                    //        .Select(a => new Author()
                    //        {
                    //            UserId = a.pu.u.Id,
                    //            CollaboratorId = a.c.Id,
                    //            Name = a.pu.u.Id != null ? $"{a.pu.u.LastName} {a.pu.u.FirstName} {a.pu.u.ThirdName}"
                    //                                    : a.c.Name
                    //        })
                    //        .ToList());
					
					}
					catch (Exception ex)
					{

					}
				return View(model);
			}
		}

		public ActionResult Create()
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				var model = new CreatePublicationViewModel
				{
					ScientificBases = db.ScientificBases.ToList(),
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
					Publication publication = new Publication()
					{
						Name = model.Name,
						FilePath = filepath,
						Pages = model.Pages,
                        Output = model.Output,
						StoringType = new StoringType() { Value = model.StoringType },
						PublicationType = new PublicationType() { Value = model.PublicationType },
						CreatedAt = DateTime.Now.ToUniversalTime(),
						PublishedAt = DateTime.Now.ToUniversalTime(),
						IsPublished = true,
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
					if (model.CollaboratorsIds != null)
					{
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
								Publication = publication
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

		

		public ActionResult Draft()
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{
				var model = db.Publications
					.Include("StoringType")
					.Include("PublicationType")
					.Where(x => x.IsPublished == true)
					.AsEnumerable()
					.Select(x => new PublicationDraft()
					{
						Id = x.Id,
						FilePath = x.FilePath,
						Name = x.Name,
						Pages = x.Pages.HasValue ? x.Pages.Value : x.Pages.Value,
						Output = x.Output,
						StoringType = ((DisplayAttribute)typeof(StoringTypeEnum)
								.GetMember(x.StoringType.Value.ToString())[0]
								.GetCustomAttributes(typeof(DisplayAttribute), false)[0]).Name,
						PublicationType = ((DisplayAttribute)typeof(StoringTypeEnum)
								.GetMember(x.PublicationType.Value.ToString())[0]
								.GetCustomAttributes(typeof(DisplayAttribute), false)[0]).Name,
						CreatedAt = x.CreatedAt,
						Collaborators = db.PublicationUsers
							.Where(p => p.PublicationId == x.Id)
							.Join(db.Publications, pu => pu.PublicationId, p => p.Id, (pu, p) => new { pu, p })
							.Join(db.Users, pup => pup.pu.UserId, u => u.Id, (pup, u) => new { pup, u })
							.Join(db.ExternalCollaborators, pu => pu.pup.pu.CollaboratorId, c => c.Id, (pu, c) => new { pu, c })
							.Select(pu => new Author()
							{
								UserId = pu.pu.u.Id,
								CollaboratorId = pu.c.Id,
								Name = pu.pu.u.Id != null ? $"{pu.pu.u.LastName} {pu.pu.u.FirstName} {pu.pu.u.ThirdName}"
														: pu.c.Name
							})
							.ToList()
					})
					.ToList();

				return View();
			}
		}
	}
}