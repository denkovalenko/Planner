using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Enums;
using Domain.Reports;
using System.ComponentModel.DataAnnotations;
using Domain.Helpers;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.IO;
using Calculation.Extensions;

namespace Calculation
{
	public static class PublicationReportBuilder
	{
		public static List<PublicationForm11> CreateForm11(ApplicationUser user)
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
					.Where(x => x.IsPublished == true)
					.Join(db.PublicationUsers, p => p.Id, pu => pu.PublicationId, (p, pu) => new { p, pu })
					.Where(x => x.pu.UserId == user.Id)
					.AsEnumerable()
					.Select(x => new PublicationForm11()
					{
						Id = x.p.Id,
						FilePath = x.p.FilePath,
						Name = x.p.Name,
						Pages = x.p.Pages.HasValue ? x.p.Pages.Value : x.p.Pages.Value,
						Output = x.p.Output,
						PublishedAt = x.p.PublishedAt.HasValue ? x.p.PublishedAt.Value : DateTime.MinValue,
						StoringType =
						((DisplayAttribute)typeof(StoringTypeEnum)
								.GetMember(x.p.StoringType.Value.ToString())[0]
								.GetCustomAttributes(typeof(DisplayAttribute), false)[0]).Name,
						PublicationType =
						((DisplayAttribute)typeof(PublicationTypeEnum)
								.GetMember(x.p.PublicationType.Value.ToString())[0]
								.GetCustomAttributes(typeof(DisplayAttribute), false)[0]).Name,
						Collaborators = new List<Author>()

					})
					.ToList();

					query.ForEach(x => x.Collaborators.AddRange(
						db.PublicationUsers
								.Where(p => p.PublicationId == x.Id)
								.Where(u => u.UserId != user.Id)
								.ToList()
								.Select(a => new Author()
								{
									UserId = a.UserId,
									CollaboratorId = a.CollaboratorId,
									Name = a.UserId != null ? $"{a.User.LastName} {a.User.FirstName} {a.User.ThirdName}"
														: a.Collaborator.Name
								})
							.ToList()));

					model = query;

				}
				catch (Exception ex)
				{

				}
				return model;
			}
		}

		public static byte[] PrintReportForm11(ApplicationUser user)
		{
			using (ExcelPackage pck = new ExcelPackage())
			{
				var datasource = CreateForm11(user);
				//Create the worksheet 
				ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Публикации " + 
					$"{user.LastName} {user.FirstName.Substring(0,1)}. {user.ThirdName.Substring(0,1)}.");

				var frmt = ws.Cells;
				frmt.Style.ShrinkToFit = false;
				frmt.Style.Indent = 5;
				frmt.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
				ws.DefaultColWidth = 200;

				ws.Column(1).AutoFit(35, 50);
				ws.Column(2).AutoFit(35, 50);
				ws.Column(3).AutoFit(35, 50);
				ws.Column(4).AutoFit(35, 50);
				ws.Column(5).AutoFit(35, 50);

				ws.Cells[1, 1].Value = "Назва";
				ws.Cells[1, 2].Value = "Характер роботи";
				ws.Cells[1, 3].Value = "Вихідні дані";
				ws.Cells[1, 4].Value = "Обсяг (стор.)";
				ws.Cells[1, 5].Value = "Співавтори";

				for (int i = 0; i < datasource.Count(); i++)
				{
					ws.Cells[i + 2, 1].Value = datasource.ElementAt(i).Name;
					ws.Cells[i + 2, 2].Value = datasource.ElementAt(i).StoringType;
					ws.Cells[i + 2, 3].Value = datasource.ElementAt(i).Output;
					ws.Cells[i + 2, 4].Value = datasource.ElementAt(i).Pages;
					if (datasource.ElementAt(i).Collaborators.Count > 0)
					{
						ws.Cells[i + 2, 5].Value = datasource.ElementAt(i).Collaborators[0].Name;
						foreach (var lab in datasource.ElementAt(i).Collaborators.Skip(1))
							ws.Cells[i + 2, 5].Value += ", " + lab.Name;
					}
					else ws.Cells[i + 2, 5].Value = "Нет соавторов";


				}

				using (ExcelRange rng = ws.Cells[1, 1, 1, 5])
				{
					rng.Style.Font.Bold = true;
					rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
					rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 200, 218, 230));  //Set color to DarkGray 
					rng.Style.Font.Color.SetColor(Color.Black);
				}
				return pck.GetAsByteArray();
				//pck.SaveAs(new FileInfo(filepath));
			}
		}

        public static List<PublicationOnDepartment> CreateDeparmentReport(string depId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var model = new List<PublicationOnDepartment>();
                try
                {
                    //all users in selected department
                    var users = db.DepartmentUsers
                        .Where(x => x.DepartmentId == depId)
                        .Join(db.Users, du => du.UserId, u => u.Id, (du, u) => new { du, u })
                        .Select(u => u.u.Id)
                        .ToList();

                    //all publications of users in department
                    var publications = db.Publications
                        .Include("PublicationType")
                        .Include("ResearchDoneType")
                        .AsEnumerable()
                        .Join(db.PublicationUsers, p => p.Id, pu => pu.PublicationId, (p, pu) => new { p, pu })
                        .Where(x => users.Any(u => u == x.pu.UserId))
                        .OrderBy(x => x.p.PublishedAt)
                        .DistinctBy(x => x.p.Id)
                        .Join(db.PublicationNMBDs, p => p.p.Id, pn => pn.PublicationId, (p, pn) => new { p, pn })
                        .AsEnumerable()
                        .Select(x => new PublicationOnDepartment()
                        {
                            Id = x.p.p.Id,
                            ImpactFactorNMBD = x.p.p.ImpactFactorNMBD,
                            NMBD = x.pn.NMBD.Name,
                            CitationNumberNMBD = x.p.p.CitationNumberNMBD,
                            Pages = x.p.p.Pages.Value,
                            IsOverseas = x.p.p.IsOverseas,
                            Name = x.p.p.Name,
                            Output = x.p.p.Output,
                            OwnerId = x.p.p.OwnerId,
                            PublicationType = ((DisplayAttribute)typeof(PublicationTypeEnum)
                                .GetMember(x.p.p.PublicationType.Value.ToString())[0]
                                .GetCustomAttributes(typeof(DisplayAttribute), false)[0]).Name,

                            ResearchDoneType = ((DisplayAttribute)typeof(ResearchDoneTypeEnum)
                                .GetMember(x.p.p.ResearchDoneType.Value.ToString())[0]
                                .GetCustomAttributes(typeof(DisplayAttribute), false)[0]).Name,
                            Collaborators = new List<Author>()

                        })
                        .ToList();

                    //add collabs
                    publications.ForEach(x => x.Collaborators.AddRange(
                        db.PublicationUsers
                                .Where(p => p.PublicationId == x.Id)
                                .ToList()
                                .Select(a => new Author()
                                {
                                    UserId = a.UserId,
                                    CollaboratorId = a.CollaboratorId,
                                    Name = a.UserId != null ? $"{a.User.LastName} {a.User.FirstName} {a.User.ThirdName}"
                                                        : a.Collaborator.Name
                                })
                            .ToList()));

                    //add department names
                    publications.ForEach(x => x.DepartmentName =
                        db.DepartmentUsers
                            .Include("Department")
                            .FirstOrDefault(d => d.UserId == x.OwnerId).Department.Name);

                    model = publications;

                }
                catch (Exception ex)
                {

                }
                return model;
            }
        }

		public static byte[] PrintDepartmentReport(string depId, string name)
		{
			using (ExcelPackage pck = new ExcelPackage())
			{
				var datasource = CreateDeparmentReport(depId);

				ExcelWorksheet ws = pck.Workbook.Worksheets.Add($"Публикации - {name}");

				var frmt = ws.Cells;
				frmt.Style.ShrinkToFit = false;
				frmt.Style.Indent = 5;
				frmt.Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.Black);
				ws.DefaultColWidth = 200;

				ws.Column(1).AutoFit(35, 50);
				ws.Column(2).AutoFit(35, 50);
				ws.Column(3).AutoFit(35, 50);
				ws.Column(4).AutoFit(35, 50);
				ws.Column(5).AutoFit(35, 50);
				ws.Column(6).AutoFit(35, 50);
				ws.Column(7).AutoFit(35, 50);
				ws.Column(8).AutoFit(35, 50);
				ws.Column(9).AutoFit(35, 50);
				ws.Column(10).AutoFit(35, 50);
				ws.Column(11).AutoFit(35, 50);
				ws.Column(12).AutoFit(35, 50);

				ws.Cells[1, 1].Value = "Автори";
				ws.Cells[1, 2].Value = "Назва роботи";
				ws.Cells[1, 3].Value = "Тип видання";
				ws.Cells[1, 4].Value = "Назва видання, дата видання (ЧЧ.ММ.РР)";
				ws.Cells[1, 5].Value = "Обсяг, ум.- друк. арк., усього";
				ws.Cells[1, 6].Value = "Обсяг, ум.- друк. арк., частка кафедри";
				ws.Cells[1, 7].Value = "За кордонне видання";
				ws.Cells[1, 8].Value = "НМБД";
				ws.Cells[1, 9].Value = "Кількість цитувань у виданнях, що входять до НМБД Scopus/Google Scolar";
				ws.Cells[1, 10].Value = "Імпакт-фактор видання, тільки з НМБД";
				ws.Cells[1, 11].Value = "За якою НДР виконано";
				ws.Cells[1, 12].Value = "Назва кафедри";

				ws.Column(6).Style.Fill.PatternType = ExcelFillStyle.Solid;
				ws.Column(7).Style.Fill.PatternType = ExcelFillStyle.Solid;
				ws.Column(8).Style.Fill.PatternType = ExcelFillStyle.Solid;
				ws.Column(9).Style.Fill.PatternType = ExcelFillStyle.Solid;
				ws.Column(10).Style.Fill.PatternType = ExcelFillStyle.Solid;
				ws.Column(12).Style.Fill.PatternType = ExcelFillStyle.Solid;
				ws.Column(6).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 216, 228, 188));
				ws.Column(7).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 216, 228, 188));
				ws.Column(8).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 216, 228, 188));
				ws.Column(9).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 216, 228, 188));
				ws.Column(10).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 216, 228, 188));
				ws.Column(12).Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 216, 228, 188));
				for (int i = 0; i < datasource.Count(); i++)
				{
					ws.Cells[i + 2, 1].Value = datasource.ElementAt(i).Collaborators[0].Name;
					foreach (var lab in datasource.ElementAt(i).Collaborators.Skip(1))
						ws.Cells[i + 2, 1].Value += ", " + lab.Name;

					ws.Cells[i + 2, 2].Value = datasource.ElementAt(i).Name;
					ws.Cells[i + 2, 3].Value = datasource.ElementAt(i).PublicationType;
					ws.Cells[i + 2, 4].Value = datasource.ElementAt(i).Output;
					ws.Cells[i + 2, 5].Value = datasource.ElementAt(i).Pages;
					ws.Cells[i + 2, 6].Value = datasource.ElementAt(i).Pages / datasource.ElementAt(i).Collaborators.Count;
					ws.Cells[i + 2, 7].Value = datasource.ElementAt(i).IsOverseas ? "Так" : "Нi";
					ws.Cells[i + 2, 8].Value = datasource.ElementAt(i).NMBD;
					ws.Cells[i + 2, 9].Value = datasource.ElementAt(i).CitationNumberNMBD;
					ws.Cells[i + 2, 10].Value = datasource.ElementAt(i).ImpactFactorNMBD;
					ws.Cells[i + 2, 11].Value = datasource.ElementAt(i).ResearchDoneType;
					ws.Cells[i + 2, 12].Value = datasource.ElementAt(i).DepartmentName;
					
				}

				using (ExcelRange rng = ws.Cells[1, 1, 1, 12])
				{
					rng.Style.Font.Bold = true;
					rng.Style.Fill.PatternType = ExcelFillStyle.Solid;        //Set Pattern for the background to Solid 
					rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 220, 230, 241));  //Set color to DarkGray 
					rng.Style.Font.Color.SetColor(Color.Black);
				}
				return pck.GetAsByteArray();
			}
		}

		public static ScientificPublishingModel ScientificPublishing(string depId, int year, int half)
		{
			using (ApplicationDbContext db = new ApplicationDbContext())
			{

				//all users in selected department
				var users = db.DepartmentUsers
					.Where(x => x.DepartmentId == depId)
					.Join(db.Users, du => du.UserId, u => u.Id, (du, u) => new { du, u })
					.Select(u => u.u.Id)
					.ToList();

				var plans = db.ScientificPublishings
					.Where(x => users.Any(u => u == x.UserId))
					.Where(x => x.Year == year)
					.ToList();

				var plan = plans.Aggregate((prev,cur) => new ScientificPublishing
					{
						Abstracts = prev.Abstracts + cur.Abstracts,
						AllPublications = prev.AllPublications + cur.AllPublications,
						ArticlesInProfessionalPublications = prev.ArticlesInProfessionalPublications + cur.ArticlesInProfessionalPublications,
						ArticlesThesesInNmbd = prev.ArticlesThesesInNmbd + prev.ArticlesThesesInNmbd,
						Monographs = prev.Monographs + cur.Monographs,
						MonographsForeignJournals = prev.MonographsForeignJournals + cur.MonographsForeignJournals,
						MonographsNationalPublications = prev.MonographsNationalPublications + cur.MonographsNationalPublications,
						ScientificArticlesInForeignLanguages = prev.ScientificArticlesInForeignLanguages + cur.ScientificArticlesInForeignLanguages,
						ScientificPublicationsInForeignJournals = prev.ScientificPublicationsInForeignJournals + cur.ScientificPublicationsInForeignJournals,
						ScientificPublicationsInScopus = prev.ScientificPublicationsInScopus + cur.ScientificPublicationsInScopus,
						Year = prev.Year
					});
				var dates = new Dates(year);
				//all publications of users in department
				var publications = db.Publications
					.Include("PublicationType")
					.AsEnumerable()
					.Join(db.PublicationUsers, p => p.Id, pu => pu.PublicationId, (p, pu) => new { p, pu })
					.Where(x => users.Any(u => u == x.pu.UserId))
					.OrderBy(x => x.p.PublishedAt)
					.Where(x => {
						if(half == 1)
						{
							return x.p.PublishedAt > dates.StartStudy && x.p.PublishedAt < dates.EndFirstHalf;
						}
						if (half == 2)
						{
							return x.p.PublishedAt > dates.EndFirstHalf && x.p.PublishedAt < dates.EndSecondHalf;
						}
						return false;
					})
					.DistinctBy(x => x.p.Id)
					.Join(db.PublicationNMBDs, p => p.p.Id, pn => pn.PublicationId, (p, pn) => new { p, pn })
					.ToList();

				var fact = new ScientificPublishing()
				{
					AllPublications = publications.Count,

					Abstracts = publications
								.Where(x => x.p.p.PublicationType.Value == PublicationTypeEnum.Abstracts).Count(),

					ArticlesInProfessionalPublications = publications
								.Where(x => x.p.p.PublicationType.Value == PublicationTypeEnum.Article).Count(),

					ArticlesThesesInNmbd = publications
								.Where(x => x.p.p.PublicationNMBDs.Count() > 0
								&& x.p.p.PublicationType.Value == PublicationTypeEnum.Article).Count(),

					MonographsForeignJournals = publications
								.Where(x => x.p.p.IsOverseas
								&& (x.p.p.PublicationType.Value == PublicationTypeEnum.Monograph
								|| x.p.p.PublicationType.Value == PublicationTypeEnum.CollectiveMonograph
								)).Count(),

					Monographs = publications
								.Where(x => x.p.p.PublicationType.Value == PublicationTypeEnum.Monograph
								|| x.p.p.PublicationType.Value == PublicationTypeEnum.CollectiveMonograph).Count(),

					MonographsNationalPublications = publications
								.Where(x => !x.p.p.IsOverseas
								&& (x.p.p.PublicationType.Value == PublicationTypeEnum.Monograph
								|| x.p.p.PublicationType.Value == PublicationTypeEnum.CollectiveMonograph
								)).Count(),

					ScientificArticlesInForeignLanguages = publications
								.Where(x => x.p.p.IsOverseas
								&& x.p.p.PublicationType.Value == PublicationTypeEnum.Article).Count(),

					ScientificPublicationsInForeignJournals = publications
								.Where(x => x.p.p.IsOverseas).Count(),

					ScientificPublicationsInScopus = publications
								.Where(x => x.p.p.PublicationNMBDs.Count() > 0)
								.Join(db.NMBDs, pnm => pnm.pn.NMBDId, nmbd => nmbd.Id, (pnm, nmbd) => new { pnm, nmbd })
								.Where(x => x.nmbd.Name == "SCOPUS").Count()
				};

				var model = new ScientificPublishingModel()
				{
					AllPublications = MakeTuple(plan.AllPublications, fact.AllPublications),

					Abstracts = MakeTuple(plan.Abstracts, fact.Abstracts),

					ArticlesInProfessionalPublications = MakeTuple(plan.ArticlesInProfessionalPublications, fact.ArticlesInProfessionalPublications),

					ArticlesThesesInNmbd = MakeTuple(plan.ArticlesThesesInNmbd, fact.ArticlesThesesInNmbd),

					MonographsForeignJournals = MakeTuple(plan.MonographsForeignJournals, fact.MonographsForeignJournals),

					Monographs = MakeTuple(plan.Monographs, fact.Monographs),

					MonographsNationalPublications = MakeTuple(plan.MonographsNationalPublications, fact.MonographsNationalPublications),

					ScientificArticlesInForeignLanguages = MakeTuple(plan.ScientificArticlesInForeignLanguages, fact.ScientificArticlesInForeignLanguages),

					ScientificPublicationsInForeignJournals = MakeTuple(plan.ScientificPublicationsInForeignJournals, fact.ScientificPublicationsInForeignJournals),

					ScientificPublicationsInScopus = MakeTuple(plan.ScientificPublicationsInScopus, fact.ScientificPublicationsInScopus), 
				};


				return model;
			}
		}

		private static Tuple<int,int,string> MakeTuple(int plan,int fact)
		{
			return new Tuple<int, int, string>(plan, fact, plan != 0 ?
					((double)fact / (double)plan * 100).ToString("F2") + "%" : "0.00%");
		}
	}
}
