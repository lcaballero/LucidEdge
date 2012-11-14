using System.Collections.Generic;
using System.Linq;
using LucidEdge.Html.ViewOrganization.HtmlDocument;


namespace LucidEdge.Html.ViewOrganization.Rendering.LinkTags
{
	public static class LinkTagExtensions
	{
		public static IEnumerable<IHtml> ToLinkTag(this string path)
		{
			return new List<string> { path }.ToLinkTags();
		}

		public static IEnumerable<IHtml> ToLinkTags(
			this IEnumerable<string> paths)
		{
			return
			paths == null
				? new List<IHtml>()
				: paths
					.Select(
						src =>
						"link".Attr(
							"href", src.ResolveUrl(),
							"rel", "stylesheet",
							"type", "text/css")
					.Add(" "));
		}
	}
}