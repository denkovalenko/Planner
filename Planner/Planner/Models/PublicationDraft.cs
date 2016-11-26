using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Models
{
	public class PublicationDraft
	{
		public String Id { get; set; }
		public String Name { get; set; }
		public String FilePath { get; set; }
		public int Pages { get; set; }
		public String StoringType { get; set; }
		public String PublicationType { get; set; }
		public String Output { get; set; }
		public DateTime CreatedAt { get; set; }
		public List<Author> Collaborators { get; set; }
	}
}
