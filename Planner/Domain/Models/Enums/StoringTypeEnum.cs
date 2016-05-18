using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Enums
{
	public enum StoringTypeEnum
	{
		[Display(Name = @"Друковане видання")]
		Print=1,
		[Display(Name = @"Електронне видання")]
		Electronic
	}
}
