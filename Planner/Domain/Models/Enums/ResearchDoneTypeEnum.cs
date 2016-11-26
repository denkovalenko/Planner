using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Enums
{
	public enum ResearchDoneTypeEnum
	{
		[Display(Name = @"Держбюджет")]
		StateBudget = 1,
		[Display(Name = @"Госпдоговірна тема")]
		ContractualTopic,
		[Display(Name = @"За індивідуальним планом викладача")]
		ForIndividualTeacherPlan,
		[Display(Name = @"Iншi")]
		Other
	}
}
