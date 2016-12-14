using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class LoadingList
    {
        public LoadingList()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public String Id { get; set; }
        public String Comment { get; set; }
        public int Year { get; set; }

        public virtual ICollection<DayEntryLoad> DayEntryLoads { get; set; }
        public virtual ICollection<ExtramuralEntryLoad> ExtramuralEntryLoads { get; set; }

        public virtual ICollection<DDataStorage> DDataStorages { get; set; }
        public virtual ICollection<EDataStorage> EDataStorages { get; set; }
    }
}
