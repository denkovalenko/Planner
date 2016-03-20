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
        public String Output { get; set; }
        public Int32 Pages { get; set; }

        public String PublicationTypeId { get; set; }
        public String PublicationFeatureId { get; set; }
        public String PublicationAccessoryId { get; set; }
        [ForeignKey("PublicationTypeId")]
        public virtual PublicationType PublicationType { get; set; }
        [ForeignKey("PublicationFeatureId")]
        public virtual PublicationFeature PublicationFeature { get; set; }
        [ForeignKey("PublicationAccessoryId")]
        public virtual PublicationAccessory PublicationAccessory { get; set; }
        public virtual ICollection<PublicationScientificBase> PublicationScientificBases { get; set; }
        public virtual ICollection<DepartmentUser> DepartmentUsers { get; set; }
    }
}
