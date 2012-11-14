using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace LucidEdge.DataBase.Execution
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
	public sealed class ColumnMappingAttribute : Attribute
	{
		public string ColumnName { get; set; }
		public Type DataType { get; set; }
		public DbType DbType { get; set; }

		public ColumnMappingAttribute() { }

		public ColumnMappingAttribute(string column, Type type, DbType dbType)
		{
			ColumnName = column;
			DataType = type;
			DbType = dbType;
		}
	}
}

