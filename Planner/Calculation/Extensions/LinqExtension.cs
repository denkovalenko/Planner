using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Extensions
{
	public static class LinqExtension
	{
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(
								this IEnumerable<TSource> source,
								Func<TSource, TKey> keySelector)
		{
			return source.GroupBy(keySelector).Select(i => i.First());
		}
	}
}
