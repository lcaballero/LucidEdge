using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.Html.Bootstrap
{
	public static partial class UI
	{
		public static class Form
		{
			public static IHtml Horizontal()
			{
				return "div.form-horizontal".Add();
			}
		}

		public static class Validation
		{
			public static IHtml Input(string name, string id = null)
			{
				return
				"input"
					.Attr("type", "text", "name", name)
					.AttrIf(id, () => new object[]{ "id", id });
			}

			public static IHtml Label(string text, string @for = null)
			{
				return
				"label.control-label"
					.Add(text)
					.AttrIf(@for, () => new object[]{ "for", @for });
			}

			public static IHtml Help(string text)
			{
				return "span.help-inline".Add(text);
			}

			public static IHtml ControlGroup(IHtml label, IHtml input, IHtml help)
			{
				return
				"div.control-group".Add(
					label,
					"div.controls".Add(
						input,
						help));
			}
		}
	}
}