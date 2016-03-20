using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class PublicationScientificBase
    {
        public PublicationScientificBase()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public String PublicationId { get; set; }
        [ForeignKey("PublicationId")]
        public virtual Publication Publications { get; set; }
        public String ScientificBaseId { get; set; }
        [ForeignKey("ScientificBaseId")]
        public virtual ScientificBase ScientificBase { get; set; }
    }
}
