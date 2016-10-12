using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class PlanConclusion
    {
        public PlanConclusion()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }

        public int Semester { get; set; }

        public string Content { get; set; }

        public string Signature { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
