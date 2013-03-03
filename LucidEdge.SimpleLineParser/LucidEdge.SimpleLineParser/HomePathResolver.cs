using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LucidEdge.SimpleLineParser
{
	/// <summary>
	/// An IPathResolver which can be provided a root (either absolute or relative) to which
	/// it will resolve paths as provided to the ResolvePath function.  It also can take 
	/// a platform specific Directory Separator Char to make the paths it produces match
	/// a desired platform.
	/// </summary>
	public class HomePathResolver : IPathResolver
	{
		/// <summary>
		/// Some directory that will be prepended to paths as the Home (~/) path.
		/// </summary>
		public string Home { get; private set; }

		/// <summary>
		/// The directory separator which this resolver uses to create paths.
		/// </summary>
		public string PathSeparator { get; private set; }

		/// <summary>
		/// Creates a resolver defaulting the Home to the CurrentDirecotry and the
		/// path separator to the system specific separator.
		/// </summary>
		public HomePathResolver()
			: this(Environment.CurrentDirectory, Path.DirectorySeparatorChar) { }

		/// <summary>
		/// Defaults the path directory separator to the system specific separator, but
		/// takes a home directory to which this intance will resolve home rooted paths.
		/// </summary>
		/// <param name="home">
		/// The directory used to resolve home rooted directories to.
		/// </param>
		public HomePathResolver(string home)
			: this(home, Path.DirectorySeparatorChar) { }

		/// <summary>
		/// New resolver will resolve home paths to the location provided and use the
		/// directory separator provided here as well.
		/// </summary>
		/// <param name="home">
		/// The directory used to resolve home rooted directories to.
		/// </param>
		/// <param name="sep">
		/// The char this resolver should use to separate directories in paths it produces.
		/// </param>
		public HomePathResolver(string home, char sep)
		{
			if (string.IsNullOrEmpty(home))
			{
				throw new ArgumentException("Home parameter cannot be null to HomePathResolver");
			}

			Home = home;
			PathSeparator = sep.ToString();
		}

		/// <summary>
		/// Implementation of IPathResovler.  Takes a path and changes a home directory
		/// designation (~/) to the home provided to this instance.  It will also
		/// use the path separator as provided to this class.
		/// </summary>
		/// <param name="s">
		/// A path to resolve.
		/// </param>
		/// <returns>
		/// The path resolved to an arbitrary 'home' (~/) directory.
		/// </returns>
		public string ResolvePath(string contentPath)
		{
			if (!string.IsNullOrEmpty(contentPath)
				&& contentPath.StartsWith("~/"))
			{
				contentPath = Path.Combine(
					Home,
					contentPath.Length > 2 ? contentPath.Substring(2) : "");
			}

			return contentPath ?? "";
		}
	}
}
