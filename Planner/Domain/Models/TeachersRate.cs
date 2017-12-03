using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TeachersRate
    {
        public TeachersRate()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public Int32 Total { get; set; }
        public String RateId { get; set; }
        [ForeignKey("RateId")]
        public virtual Rate Rate { get; set; }

        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
