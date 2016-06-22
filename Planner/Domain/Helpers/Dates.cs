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
			//if(DateTime.Now.Month >= 9 && DateTime.Now.Month <= 12)
			//{
				//ok
				//if (half == 1)
				//{
					StartStudy = new DateTime(year, 9, 1);
					EndFirstHalf = new DateTime(year + 1, 1, 15);
					EndSecondHalf = new DateTime(year + 1, 6, 30);
				//}
				//if (half == 2)
				//{
				//	StartStudy = new DateTime(year - 1, 9, 1);
				//	EndFirstHalf = new DateTime(year, 1, 15);
				//	EndSecondHalf = new DateTime(year, 6, 30);
				//}
			//}
			//if (DateTime.Now.Month >= 2 && DateTime.Now.Month <= 16)
			//{
				//ok
				//if (half == 1)
				//{
				//	StartStudy = new DateTime(year-1, 9, 1);
				//	EndFirstHalf = new DateTime(year, 1, 15);
				//	EndSecondHalf = new DateTime(year, 6, 30);
				//}
				//if (half == 2)
				//{
				//	StartStudy = new DateTime(year - 1, 9, 1);
				//	EndFirstHalf = new DateTime(year, 1, 15);
				//	EndSecondHalf = new DateTime(year, 6, 30);
				//}
			//}


		}
	}
}
