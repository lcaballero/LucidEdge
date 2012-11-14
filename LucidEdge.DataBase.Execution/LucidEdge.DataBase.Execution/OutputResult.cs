using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace LucidEdge.DataBase.Execution
{
	public class OutputResult
	{
		public int? FieldCount { get; set; }
		public string TableName { get; set; }
		public List<OutputColumn> Columns { get; set; }
		public List<List<OutputPoint>> DataPoints { get; set; }

		public OutputResult()
		{
			Columns = new List<OutputColumn>();
			DataPoints = new List<List<OutputPoint>>();
		}

		public override string ToString()
		{
			return
			DataPoints
				.Aggregate(
					0,
					new StringBuilder(),
					(acc, result, n) =>
					result.Aggregate(
						0,
						acc,
						(acc2, dps, k) =>
						acc2.AppendFormat("{0}.{1}.", n, k)
							.Append(dps.ColumnName)
							.AppendFormat(":{0}", dps.DataType.Name)
							.AppendFormat(":{0}", dps.Value)
							.AppendLine()))
				.ToString();
		}
	}
}
