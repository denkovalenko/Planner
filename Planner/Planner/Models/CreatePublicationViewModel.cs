using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Enums;

namespace Planner.Models
{
    public class CreatePublicationViewModel
    {
        //public List<Author> Collaborators { get; set; }
        public List<ScientificBase> ScientificBases { get; set; }
		public StoringTypeEnum StoringType { get; set; }

	}
}
