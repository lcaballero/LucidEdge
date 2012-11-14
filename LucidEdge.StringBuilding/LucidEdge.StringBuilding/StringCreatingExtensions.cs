using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LucidEdge.StringBuilding.Helpers;


namespace LucidEdge.StringBuilding
{
	public static class StringCreatingExtensions
	{
		public static StringBuilder Dupes(this string s, int count)
		{
			return
			(0).To(count)
				.Aggregate(
					new StringBuilder(),
					(buf, n) => buf.Append(s));
		}

		public static string Tabs(this int depth, string tabValue)
		{
			return
			(0).To(depth)
			   .Aggregate(
					new StringBuilder(),
					(buf, n) => buf.Append(tabValue))
				.ToString();
		}
	}
}
