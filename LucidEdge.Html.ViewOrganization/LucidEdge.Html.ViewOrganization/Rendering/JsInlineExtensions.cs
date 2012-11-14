using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LucidEdge.Html;


namespace LucidEdge.Html.ViewOrganization.Rendering.CombinedInlines
{
	public static class JsInlineExtensions
	{
		public static IHtml ToInline(
			this IEnumerable<string> lines,
			IEnumerable<Type> types = null)
		{
			return
			"script"
				.Attr("type", "text/javascript")
				.Add(string.Join("\n",
					lines.Concat(types.ToRenderables().Select(r => r.ToHtml().ToString()))
						.ToArray()));
		}

		public static IEnumerable<IHtmlRenderable> ToRenderables(
			this IEnumerable<Type> modules)
		{
			return
			modules == null
				? new List<IHtmlRenderable>()
				: modules.Select(
					t => (IHtmlRenderable)Activator.CreateInstance(t));
		}
	}
}
