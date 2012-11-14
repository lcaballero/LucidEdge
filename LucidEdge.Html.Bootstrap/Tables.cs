using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.Html.Bootstrap
{
	public static partial class UI
	{
		public static IHtml AsStripedTable(this IHtml e)
		{
			return e.AddClass("table-striped");
		}

		public static IHtml AsBorderedTable(this IHtml e)
		{
			return e.AddClass("table-bordered");
		}

		public static IHtml AsCondensedTable(this IHtml e)
		{
			return e.AddClass("table-condensed");
		}

		public static IHtml WithRowHover(this IHtml e)
		{
			return e.AddClass("table-hover");
		}

		public static IHtml Table()
		{
			return "table.table".Add();
		}

		public static IHtml WithSuccess(IHtml e)
		{
			return e.AddClass("success");
		}

		public static IHtml WithError(IHtml e)
		{
			return e.AddClass("error");
		}

		public static IHtml WithWarning(IHtml e)
		{
			return e.AddClass("warning");
		}

		public static IHtml WithInfo(IHtml e)
		{
			return e.AddClass("info");
		}
	}
}
