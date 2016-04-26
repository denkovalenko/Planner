using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class Department
    {
        public Department()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public String Name { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<DepartmentUser> DepartmentUsers { get; set; }
    }
}
