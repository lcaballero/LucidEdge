using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.Html.Bootstrap
{
	public class NavItem
	{
		public string Text { get; set; }
		public string Href { get; set; }
		public string Action { get; set; }

		public string[] ItemAttributes { get; set; }
		public string[] ItemClasses { get; set; }

		public string[] AnchorAttributes { get; set; }
		public string[] AnchorClasses { get; set; }

		public bool IsHidden { get; set; }
	}
}
