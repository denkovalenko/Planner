using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class PlanRemark
    {
        public PlanRemark()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Remark { get; set; }

        public string Signature { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
