using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.Html.Bootstrap
{
	public static partial class UI
	{
		public static class Buttons
		{
			public static IHtml Default(string text)
			{
				return "button.btn".Attr("type", "button").Add(text);
			}

			public static IHtml Primary(string text)
			{
				return Default(text).AddClass("btn-primary");
			}

			public static IHtml Info(string text)
			{
				return Default(text).AddClass("btn-info");
			}

			public static IHtml Success(string text)
			{
				return Default(text).AddClass("btn-success");
			}

			public static IHtml Warning(string text)
			{
				return Default(text).AddClass("btn-warning");
			}

			public static IHtml Danger(string text)
			{
				return Default(text).AddClass("btn-danger");
			}

			public static IHtml Inverse(string text)
			{
				return Default(text).AddClass("btn-inverse");
			}

			public static IHtml Link(string text)
			{
				return Default(text).AddClass("btn-link");
			}
		}
	}
}
