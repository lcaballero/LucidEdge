using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;


namespace LucidEdge.SimpleLineParser
{
	public static class PathNomalizingExtensions
	{
		private static Regex re = new Regex(@"/|\\");

		public static string NormalizePathSeparators(this string path)
		{
			return path.NormalizePathSeparators(Path.DirectorySeparatorChar);
		}

		public static string NormalizePathSeparators(this string path, char sep)
		{
			return re.Replace(path, sep.ToString());
		}
	}
}
