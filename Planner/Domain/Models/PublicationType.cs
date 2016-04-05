using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class PublicationType
    {
        public PublicationType()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public PublicationsTypeEnum PublicationTypeValue { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
