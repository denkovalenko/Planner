using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
	public class ScientificPublishingModel
	{
		public Tuple<int, int, double> Monographs { get; set; }
		public Tuple<int, int, double> MonographsNationalPublications { get; set; }
		public Tuple<int, int, double> MonographsForeignJournals { get; set; }
		public Tuple<int, int, double> AllPublications { get; set; }
		public Tuple<int, int, double> ScientificPublicationsInScopus { get; set; }
		public Tuple<int, int, double> ArticlesThesesInNmbd { get; set; }
		public Tuple<int, int, double> ScientificPublicationsInForeignJournals { get; set; }
		public Tuple<int, int, double> ArticlesInProfessionalPublications { get; set; }
		public Tuple<int, int, double> ScientificArticlesInForeignLanguages { get; set; }
		public Tuple<int, int, double> Abstracts { get; set; }
	}
}
