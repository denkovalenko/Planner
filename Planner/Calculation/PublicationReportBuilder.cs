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

		public static byte[] ReportForm11(ApplicationUser user)
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
					ws.Cells[i + 2, 5].Value = datasource.ElementAt(i).Collaborators[0].Name;
					foreach (var lab in datasource.ElementAt(i).Collaborators.Skip(1))
						ws.Cells[i + 2, 5].Value += ", " + lab.Name;
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
	}
}
