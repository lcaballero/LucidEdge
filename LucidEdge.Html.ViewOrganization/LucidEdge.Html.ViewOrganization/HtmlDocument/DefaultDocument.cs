using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LucidEdge.Html.ViewOrganization.Rendering.LinkTags;


namespace LucidEdge.Html.ViewOrganization.HtmlDocument
{
	public class DefaultDocument : Document
	{
		public override IHtml ToHtml()
		{
			return
			Html.Add(
				Head,
				Body.Add(Content));
		}
	}
}
