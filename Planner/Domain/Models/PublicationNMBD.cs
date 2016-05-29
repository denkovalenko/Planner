using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class PublicationNMBD
    {
        public PublicationNMBD()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public String PublicationId { get; set; }
        [ForeignKey("PublicationId")]
        public virtual Publication Publications { get; set; }
        public String NMBDId { get; set; }
        [ForeignKey("NMBDId")]
        public virtual NMBD NMBD { get; set; }
    }
}
