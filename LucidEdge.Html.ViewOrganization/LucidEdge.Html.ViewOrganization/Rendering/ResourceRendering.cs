using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using LucidEdge.Html;
using LucidEdge.Html.ViewOrganization.Controllers.ActionFilters;
using LucidEdge.Html.ViewOrganization.HtmlDocument;
using LucidEdge.Html.ViewOrganization.Rendering.LinkTags;
using LucidEdge.Html.ViewOrganization.Rendering.ScriptTags;
using LucidEdge.SimpleLineParser;


namespace LucidEdge.Html.ViewOrganization.Rendering
{
	public static class ResourceRendering
	{
		public static IEnumerable<IHtml> ToLinkTags(this IDocument doc)
		{
			return doc.ToStylePaths().ToLinkTags();
		}

		public static IEnumerable<IHtml> ToScriptTags(this IDocument doc)
		{
			return doc.ToScriptPaths().ToScriptTags();
		}

		/// <summary>
		/// Paths are combined in this order:
		/// 
		/// 1) Packages added by the StylePackages attributes.
		/// 2) Packages add to the Document itself.
		/// 3) Styles added via the Styles attributes.
		/// 4) Styles add to the Document itself.
		/// </summary>
		/// <param name="doc">
		/// A document that may or may not contain additional package and style paths.
		/// </param>
		/// <returns>
		/// Combined list of .css files as found via the above mechanisms.
		/// </returns>
		public static IEnumerable<string> ToStylePaths(this IDocument doc)
		{
			var contextPackages = FilterActionItems.StylesheetPackages ?? new List<string>();

			var documentPackages =
				doc == null || doc.Resources == null || doc.Resources.CssPackages == null
					? new List<string>()
					: (doc.Resources.CssPackages ?? new List<string>());

			var contextCss = FilterActionItems.Styles ?? new List<string>();
			var documentCss =
				doc == null || doc.Resources == null || doc.Resources.CombinedCss == null
					? new List<string>()
					: (doc.Resources.CombinedCss ?? new List<string>());

			var lines = contextPackages
				.Concat(documentPackages)
				.SelectMany(
					s =>
					LinesReader.Parse(
						File.ReadAllText(FilterActionItems.HomeResolver.ResolveUrl(s))))
				.Concat(documentPackages)
				.ToList();

			return lines;
		}

		public static IEnumerable<string> ToScriptPaths(this IDocument doc)
		{
			var contextPackages = FilterActionItems.JavaScriptPackages ?? new List<string>();

			var documentPackages =
				doc == null || doc.Resources == null || doc.Resources.JsPackages == null
					? new List<string>()
					: (doc.Resources.JsPackages ?? new List<string>());

			var contextCss = FilterActionItems.Scripts ?? new List<string>();

			var documentCss =
				doc == null || doc.Resources == null || doc.Resources.CombinedJs == null
					? new List<string>()
					: (doc.Resources.CombinedJs ?? new List<string>());

			var lines = contextPackages
				.Concat(documentPackages)
				.SelectMany(
					s =>
					LinesReader.Parse(
						File.ReadAllText(FilterActionItems.HomeResolver.ResolveUrl(s))))
				.Concat(documentPackages)
				.ToList();

			return lines;

		}
	}
}
