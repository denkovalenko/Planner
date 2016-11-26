using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PublicationUser
    {
        public PublicationUser()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
		public Double PageQuantity { get; set; }

		public String PublicationId { get; set; }
        [ForeignKey("PublicationId")]
        public virtual Publication Publication { get; set; }

        public String UserId { get; set; }
		[ForeignKey("UserId")]
		public virtual ApplicationUser User { get; set; }

		public String CollaboratorId { get; set; }
		[ForeignKey("CollaboratorId")]
		public virtual ExternalCollaborator Collaborator { get; set; }
    }
}
