using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class PlanScientificWork
    {
        public PlanScientificWork()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }

        public int OrderNumber { get; set; }
        public string Content { get; set; }
        public string SchemaName { get; set; }
        public string Result { get; set; }
        public int DurationTime { get; set; }
        public int PlannedVolume { get; set; }
        public int ActualVolume { get; set; }
        public virtual ICollection<PlanAllocation> PlanAllocations { get; set; }
    }
}
