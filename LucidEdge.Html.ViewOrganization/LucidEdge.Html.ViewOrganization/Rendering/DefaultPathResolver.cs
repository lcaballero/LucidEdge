using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LucidEdge.Html.ViewOrganization.Rendering
{
	public class DefaultPathResolver : IPathResolver
	{
		public string ResolveUrl(string href)
		{
			if (href.StartsWith("~/"))
			{
				return VirtualPathUtility.ToAbsolute("~/") + href.Substring(2);
			}

			return href;
		}
	}
}