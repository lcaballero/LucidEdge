using System;


namespace LucidEdge.DataBase.Execution
{
	public class OutputColumn
	{
		public string ColumnName { get; set; }
		public Type DataType { get; set; }
		public int Ordinal { get; set; }
	}
}
