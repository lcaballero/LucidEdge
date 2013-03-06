using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.DataMapping
{
	public static class BuildDataPoints
	{
		public static IEnumerable<IDataPoint> Add()
		{
			return null;
		}

		public static IEnumerable<IDataPoint> Add(
			this IEnumerable<IDataPoint> dp, string name, object val)
		{
			return dp.Concat(new DataPoint(name, val).Lift());
		}
	}
}
