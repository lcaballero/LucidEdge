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

		/// <summary>
		/// The columns found in the table.
		/// </summary>
		public List<OutputColumn> Columns { get; set; }

		/// <summary>
		/// Accumulates a list of data points in the form of Results and
		/// Rows.  Each data point typically maps to a column and those
		/// columns are typically mapped to a property in a strongly
		/// typed map.
		/// </summary>
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
