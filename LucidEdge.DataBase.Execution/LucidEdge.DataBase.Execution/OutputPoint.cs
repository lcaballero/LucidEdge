using System;
using System.Data;


namespace LucidEdge.DataBase.Execution
{
	public class OutputPoint
	{
		public string ColumnName { get; set; }
		public Type DataType { get; set; }
		public DbType DbType { get; set; }
		public int Ordinal { get; set; }
		public object Value { get; set; }
		public object Target { get; set; }

		public OutputPoint() {}

		public OutputPoint(string col, object value)
		{
			Value = value;
			ColumnName = col;
			DataType = value.GetType();
			DbType = DataType.ToDbType();
		}
	}
}
