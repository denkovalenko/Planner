using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Position
    {
        public Position()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public PositionEnum PositionValue { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
