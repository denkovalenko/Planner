using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class NMBD
	{
		public NMBD()
		{
			Id = Guid.NewGuid().ToString();
		}
		[Key]
		public String Id { get; set; }
		public String Name { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
	}
}
