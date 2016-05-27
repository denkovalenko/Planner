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
        public String Output { get; set; }

		public List<String> CollaboratorsIds { get; set; }
		public List<String> NewCollaboratorsNames { get; set; }

		//public List<Tuple<String,double>> CollaboratorsIds { get; set; }
		//public List<Tuple<String, double>> NewCollaboratorsNames { get; set; }
		public Double Pages { get; set; }
		public Boolean IsOverseas { get; set; }
		public String NMBDId { get; set; }
		public int CitationNumberNMBD { get; set; }
		public ResearchDoneTypeEnum ResearchDoneType { get; set; }
		public StoringTypeEnum StoringType { get; set; }
		public PublicationTypeEnum PublicationType { get; set; }
	}
}
