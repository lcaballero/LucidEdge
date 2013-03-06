using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.DataMapping
{
	public interface IDataPoint
	{
		string ColumnName { get; set; }
		Type DataType { get; set; }
		int? Ordinal { get; set; }
		object Value { get; set; }
	}
}
