using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Planner.Models
{
    public class CreatePublicationViewModel
    {
        public IEnumerable<Author> Collaborators { get; set; }
        public IEnumerable<ScientificBase> ScientificBases { get; set; }
    }
}
