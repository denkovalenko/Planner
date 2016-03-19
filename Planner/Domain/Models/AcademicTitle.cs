using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class AcademicTitle
    {
        public AcademicTitle()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public AcademicTitleEnum PositionValue { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
