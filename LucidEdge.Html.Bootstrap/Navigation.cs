using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.Html.Bootstrap
{
	public static partial class UI
	{
		public static IHtml AsNavSideBar(this IHtml h)
		{
			return h.AddClass("nav-sidebar");
		}

		public static class Nav
		{
			public static IHtml SideBar(NavCollection coll)
			{
				return
				"ul.nav.nav-list".Add(
					coll.Items
						.Where(nv => !nv.IsHidden)
						.Select(nv => RenderItem(coll, nv)));
			}

			public static IHtml RenderItem(NavCollection coll, NavItem nv)
			{
				return
				"li".Add(
						"a".Add(nv.Text).Attr("href", nv.Href))
					.AddClassIf(coll.ActiveAction == nv.Action, () => "active");
			}
		}
	}
}
