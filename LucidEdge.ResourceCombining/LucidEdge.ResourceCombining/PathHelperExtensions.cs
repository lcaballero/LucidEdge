using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LucidEdge.ResourceCombining
{
	public static class PathHelperExtensions
	{
		private static Regex _AbsoluteUrlExpression = new Regex(@".*?://.*?");

		public static bool IsAbsoluteUrl(this string s)
		{
			return _AbsoluteUrlExpression.IsMatch(s);
		}

		/// <summary>
		/// Replaces the '/' forward slash with the backslash in the path '\'.
		/// </summary>
		/// <param name="path">
		/// A path separated with a '\' perhaps.
		/// </param>
		/// <returns>
		/// A path where '\' is replaced with '/'.
		/// </returns>
		public static string NormalizePath(this string path)
		{
			return path.Replace('/', '\\');
		}

		public static string WithPathEnd(this string path)
		{
			return path.NormalizePath().AppendDirectorySeparator();
		}

		private static string AppendDirectorySeparator(this string path)
		{
			return path.EndsWith("\\") ? path : path + "\\";
		}

		public static string ToControllerDir(this string name)
		{
			return
			name.EndsWith("Controller")
				// 'Controller' is 10 chars long
				? name.Substring(0, name.Length - 10) 
				: name;
		}
	}
}
