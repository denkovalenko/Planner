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
		public String ScientificBaseId { get; set; }
	}
}
