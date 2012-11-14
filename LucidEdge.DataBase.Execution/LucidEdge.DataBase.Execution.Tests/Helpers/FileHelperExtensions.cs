using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LucidEdge.DataBase.Execution.Tests
{
	public static class FileHelperExtensions
	{
		public static string Read(this string path)
		{
			return
			File.ReadAllText(
				Environment.CurrentDirectory
				+ "/../../"
				+ path);
		}
	}
}
