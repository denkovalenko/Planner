using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ScientificPublishing
    {
        public ScientificPublishing()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }

        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
		[Range(1930,2100,ErrorMessage = "Дата выходит за предел")]
        public int Year { get; set; }

        public int Monographs { get; set; }
        public int MonographsNationalPublications { get; set; }
        public int MonographsForeignJournals { get; set; }
        public int AllPublications { get; set; }
        public int ScientificPublicationsInScopus { get; set; }
        public int ArticlesThesesInNmbd { get; set; }
        public int ScientificPublicationsInForeignJournals { get; set; }
        public int ArticlesInProfessionalPublications { get; set; }
        public int ScientificArticlesInForeignLanguages { get; set; }
        public int Abstracts { get; set; }
    }
}
