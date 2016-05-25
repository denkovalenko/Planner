using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Publication
    {
        public Publication()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }
        public String FilePath { get; set; }
		public int? Pages { get; set; }
		public String Output { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? PublishedAt { get; set; }
		public Boolean IsPublished { get; set; }
		public String StoringTypeId { get; set; }
		[ForeignKey("StoringTypeId")]
		public virtual StoringType StoringType { get;set;}

		public String PublicationTypeId { get; set; }
		[ForeignKey("PublicationTypeId")]
		public virtual PublicationType PublicationType { get; set; }
		public virtual ICollection<PublicationScientificBase> PublicationScientificBases { get; set; }
        public virtual ICollection<PublicationUser> PublicationUsers { get; set; }
    }
}
