using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class PublicationFeature
    {
        public PublicationFeature()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public PublicationsFeatureEnum PublicationFeatureValue { get; set; }
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
