using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Models
{
	public class PublicationCreate
	{
		public String Name { get; set; }
		public List<String> CollaboratorsIds { get; set; }
		public List<String> NewCollaboratorsNames { get; set; }
		public String ScientificBaseId { get; set; }
		public int Pages { get; set; }
		public StoringTypeEnum StoringType { get; set; }
	}
}
