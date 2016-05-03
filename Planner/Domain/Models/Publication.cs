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
        public Boolean PublishedStatus { get; set; }
        public virtual ICollection<PublicationScientificBase> PublicationScientificBases { get; set; }
        public virtual ICollection<PublicationUser> PublicationUsers { get; set; }
    }
}
