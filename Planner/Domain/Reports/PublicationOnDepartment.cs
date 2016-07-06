using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reports
{
    public class PublicationOnDepartment
    {
        public String Id { get; set; }
        public Double ImpactFactorNMBD { get; set; }
        public String NMBD { get; set; }
        public Double CitationNumberNMBD { get; set; }
        public Double Pages { get; set; }
        public Boolean IsOverseas { get; set; }
        public String Name { get; set; }
        public String Output { get; set; }
        public String PublicationType { get; set; }
        public String ResearchDoneType { get; set; }
        public List<Author> Collaborators { get; set; }
        public String OwnerId { get; set; }
        public String DepartmentName { get; set; }
		public DateTime? Start { get; set; }
		public DateTime? End { get; set; }

	}
}
