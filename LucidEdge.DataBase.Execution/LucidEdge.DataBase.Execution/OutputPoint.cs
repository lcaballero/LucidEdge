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
	}
}
