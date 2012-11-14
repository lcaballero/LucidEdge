using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.Html
{
	internal static class Base
	{
		/// <summary>
		/// Simply creates an IEnumerable of the integers moving
		/// forward in sequence between 'from' and 'to'.
		/// </summary>
		/// <param name="from">
		/// The starting integer for IEnumerable.
		/// </param>
		/// <param name="to">
		/// The non-inclusive last value of the IEnumerable.
		/// </param>
		/// <returns>
		/// The sequence of integers 'from' to 'to'.
		/// </returns>
		internal static IEnumerable<int> To(this int from, int to)
		{
			for (int i = from; i < to; i++)
			{
				yield return i;
			}
		}

		internal static IEnumerable<T> Lift<T>(this T t)
		{
			yield return t;
		}
	}
}
