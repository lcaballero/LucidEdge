using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.Html.Bootstrap
{
	public class NavCollection
	{
		public string ActiveAction { get; set; }
		public string CurrentAction { get; set; }
		public List<NavItem> Items { get; set; }

		public NavCollection(IEnumerable<NavItem> nav)
		{
			Items = nav.ToList();
		}
	}
}
