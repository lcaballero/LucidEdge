using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LucidEdge.DataBase.Execution
{
	public class ColumnMapping
	{
		public PropertyInfo PropertyInfo { get; private set; }
		public ColumnMappingAttribute ColumnMap { get; private set; }
		public object Source { get; set; }
		public bool IsMarkedIgnored { get; set; }
		public object Value { get; set; }

		protected IgnoreColumnAttribute Ignored { get; set; }

		public ColumnMapping(PropertyInfo p, object source)
		{
			if (p == null || source == null)
			{
				throw new ArgumentException(
					"Constructor requires a non-null property info and source instance.");
			}

			Source = source;
			PropertyInfo = p;
			ColumnMap = p.FindAttribute<ColumnMappingAttribute>().FirstOrDefault();
			Ignored = p.FindAttribute<IgnoreColumnAttribute>().FirstOrDefault();
			IsMarkedIgnored = Ignored != null;
		}
	}
}
