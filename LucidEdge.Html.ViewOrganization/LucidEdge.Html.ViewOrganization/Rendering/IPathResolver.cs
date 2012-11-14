using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LucidEdge.Html.ViewOrganization.Rendering
{
	public interface IPathResolver
	{
		string ResolveUrl(string href);
	}
}