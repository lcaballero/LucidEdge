using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LucidEdge.DataBase.Execution
{
	[AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
	public sealed class IgnoreColumnAttribute : Attribute
	{
		public IgnoreColumnAttribute() { }
	}
}
