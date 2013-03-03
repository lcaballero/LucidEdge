using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace LucidEdge.Html.ViewOrganization.Rendering
{
	public class AppHomePathResolver : IPathResolver
	{
		private static Regex re = new Regex(@"/|\\");

		public string HomePath { get; set; }

		public string ResolveUrl(string href)
		{
			if (href.StartsWith("~/"))
			{
				var path = (HomePath ?? "") + href.Substring(2);

				return NormalizePathSeparators(path);
			}

			return href;
		}

		private string NormalizePathSeparators(string path)
		{
			return NormalizePathSeparators(path, Path.DirectorySeparatorChar);
		}

		private string NormalizePathSeparators(string path, char sep)
		{
			return re.Replace(path, sep.ToString());
		}
	}
}
