using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class Dates
    {
        public DateTime StartStudy { get; private set; }
        public DateTime EndFirstHalf { get; private set; }
        public DateTime EndSecondHalf { get; private set; }

        public Dates(int year)
        {

            StartStudy = new DateTime(year, 9, 1);
            EndFirstHalf = new DateTime(year + 1, 1, 15);
            EndSecondHalf = new DateTime(year + 1, 8, 30);

        }
    }
}
