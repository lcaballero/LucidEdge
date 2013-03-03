using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.SimpleLineParser
{
	public interface IPathResolver
	{
		/// <summary>
		/// Used to transform arbitrarily paths, such as those that begin with
		/// ~/ or / or simply a relative path like File.txt, etc.
		/// </summary>
		/// <param name="path">
		/// Absolute or relative path.
		/// </param>
		/// <returns>
		/// Path resolved to a current, home or root directory.
		/// </returns>
		string ResolvePath(string path);
	}
}
