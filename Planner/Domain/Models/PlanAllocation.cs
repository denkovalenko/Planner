using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class PlanAllocation
    {
        public PlanAllocation()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }

        public string WorkTypes { get; set; }
        public int PlannedVolume { get; set; }
        public int ActualVolume { get; set; }

        public String PlanTrainingJobId { get; set; }
        [ForeignKey("PlanTrainingJobId")]
        public virtual PlanTrainingJob PlanTrainingJob { get; set; }

        public String PlanManagmentId { get; set; }
        [ForeignKey("PlanManagmentId")]
        public virtual PlanManagment PlanManagment { get; set; }

        public String PlanMethodicalWorkId { get; set; }
        [ForeignKey("PlanMethodicalWorkId")]
        public virtual PlanMethodicalWork PlanMethodicalWork { get; set; }

        public String PlanScientificWorkId { get; set; }
        [ForeignKey("PlanScientificWorkId")]
        public virtual PlanScientificWork PlanScientificWork { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
