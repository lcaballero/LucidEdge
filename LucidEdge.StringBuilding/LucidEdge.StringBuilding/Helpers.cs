using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.StringBuilding.Helpers
{
	public static class Helpers
	{
		public static IEnumerable<int> To(this int from, int to)
		{
			for (int i = from; i < to; i++)
			{
				yield return i;
			}
		}

		public static TAccumulate Aggregate<TSource, TAccumulate>(
			this IEnumerable<TSource> source,
			TAccumulate seed,
			Func<TAccumulate, TSource, int, TAccumulate> func)
		{
			int index = 0;

			return source.Aggregate(seed, (acc, item) => func(acc, item, index++));
		}
	}
}
