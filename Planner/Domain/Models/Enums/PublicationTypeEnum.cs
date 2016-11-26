using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Enums
{
	public enum PublicationTypeEnum
	{
		[Display(Name = @"Тези доповіді")]
		Abstracts=1,
		[Display(Name = @"Стаття")]
		Article,
		[Display(Name = @"Звіт про НДР")]
		ScientificReport,
		[Display(Name = @"Патент")]
		Patent,
		[Display(Name = @"Навчальний посібник")]
		Tutorial,
		[Display(Name = @"Лабораторний практикум")]
		LaboratoryWorkshop,
		[Display(Name = @"Монографія")]
		Monograph,
		[Display(Name = @"Робоча програма")]
		WorkProgram,
		[Display(Name = @"Навчально-практичний поcібник")]
		EducationalAndPracticalGuide,
		[Display(Name = @"Коллективная монография")]
		CollectiveMonograph,
		[Display(Name = @"Електронний навчальний посібник ")]
		ElectronicTextbook

	}
}
