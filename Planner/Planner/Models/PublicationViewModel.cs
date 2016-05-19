using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner.Models
{
    public class PublicationViewModel
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Text { get; set; }
        public Int32 Pages { get; set; }

        public String PublicationTypeId { get; set; }
        public String PublicationFeatureId { get; set; }
        public String PublicationAccessoryId { get; set; }
        public Boolean PublishedStatus { get; set; }

        public virtual String ScientificBaseId { get; set; }
    }
}
