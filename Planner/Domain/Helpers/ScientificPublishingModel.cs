using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
	public class ScientificPublishingModel
	{
		public Tuple<int, int, string> Monographs { get; set; }
		public Tuple<int, int, string> MonographsNationalPublications { get; set; }
		public Tuple<int, int, string> MonographsForeignJournals { get; set; }
		public Tuple<int, int, string> AllPublications { get; set; }
		public Tuple<int, int, string> ScientificPublicationsInScopus { get; set; }
		public Tuple<int, int, string> ArticlesThesesInNmbd { get; set; }
		public Tuple<int, int, string> ScientificPublicationsInForeignJournals { get; set; }
		public Tuple<int, int, string> ArticlesInProfessionalPublications { get; set; }
		public Tuple<int, int, string> ScientificArticlesInForeignLanguages { get; set; }
		public Tuple<int, int, string> Abstracts { get; set; }
        public String DepartmentName { get; set; }
        public String Period { get; set; }
	}
}
