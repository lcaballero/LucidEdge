using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;


namespace LucidEdge.DataBase.Execution
{
	public static class HelperExtensions
	{
		public static DbType ToDbType(this Type t)
		{
			return
			t == typeof(string)
				? DbType.String
				:
			t == typeof(int) || t == typeof(int?)
				? DbType.Int32
				:
			t == typeof(long) || t == typeof(long?)
				? DbType.Int64
				:
			t == typeof(double) || t == typeof(float)
			|| t == typeof(double?) || t == typeof(float?)
				? DbType.Double
				:
			t == typeof(bool) || t == typeof(bool?)
				? DbType.Boolean
				:
			t == typeof(DateTime) || t == typeof(DateTime?)
				? DbType.DateTime
				:
			t == typeof(DateTimeOffset) || t == typeof(DateTimeOffset?)
				? DbType.DateTimeOffset
				:
			DbType.Object;
		}

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

		public static IEnumerable<T> While<T,TReader>(
			this TReader reader,
			Predicate<TReader> continueFn,
			Func<TReader, int, T> itemProvider)
		{
			int row = 0;
			while (continueFn(reader))
			{
				yield return itemProvider(reader, row++);
			}
		}
	}
}
