using System.Collections.Generic;
using System.Linq;
using LucidEdge.Html.ViewOrganization.HtmlDocument;
using LucidEdge.Html.ViewOrganization.Rendering;


namespace LucidEdge.Html.ViewOrganization.Rendering.ScriptTags
{
	public static class ScriptTagExtensions
	{
		public static IEnumerable<IHtml> ToScriptTag(this string path)
		{
			return new List<string> { path }.ToScriptTags();
		}

		public static IEnumerable<IHtml> ToScriptTags(this IEnumerable<string> paths)
		{
			return
			paths
				.Select(
					src =>
					"script".Attr(
						"type", "text/javascript",
						"src", src.ResolveUrl())
				.Add(" "));
		}
	}
}



