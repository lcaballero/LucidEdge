using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.ResourceCombining.Tests
{
	public static class HelperExtensions
	{
		public static List<T> Output<T>(this IEnumerable<T> items)
		{
			return items.Output(null).ToList();
		}

		public static IEnumerable<T> Output<T>(
			this IEnumerable<T> items,
			Func<T,T> write)
		{
			return items.Select(write ?? ((t) => Write<T>(t)));
		}

		public static T Write<T>(this T t)
		{
			var s = t.ToString();

			Console.WriteLine(s);

			return t;
		}
	}
}
