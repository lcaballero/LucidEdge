using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace LucidEdge.DataBase.Execution
{
	public static class HelperExtensions
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
			int n,
			TAccumulate seed,
			Func<TAccumulate, TSource, int, TAccumulate> func)
		{
			return source.Aggregate(seed, (acc, item) => func(acc, item, n++));
		}
	}
}
