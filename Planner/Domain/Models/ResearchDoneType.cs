using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class ResearchDoneType
	{
		public ResearchDoneType()
		{
			Id = Guid.NewGuid().ToString();
		}
		[Key]
		public String Id { get; set; }
		public ResearchDoneTypeEnum Value { get; set; }
		public virtual ICollection<Publication> Publications { get; set; }
	}
}
