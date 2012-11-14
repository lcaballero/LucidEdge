using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LucidEdge.Html.ViewOrganization.HtmlDocument
{
	public class HtmlContainer : IHtmlRenderable
	{
		/// <summary>
		/// Based on how the HtmlContainer was created.  The default constructor
		/// creates an HtmlContainer that is a fragment, while the other Costructors
		/// create an HtmlContainer as an Element.
		/// </summary>
		public IHtml Container { get; protected set; }

		/// <summary>
		/// Creates a module based on a Fragment, instead of an Html Element.
		/// </summary>
		public HtmlContainer()
		{
			Container = new Html();
		}

		/// <summary>
		/// This creates a container based on the tagDef provided, and if null, then
		/// the container is a div, without any attributes.
		/// </summary>
		/// <param name="tagDef">
		/// Uses the CSS selectors using the format tag#id.class1.class2, etc.
		/// </param>
		public HtmlContainer(string tagDef)
		{
			Container = (tagDef ?? "div").Add();
		}

		/// <summary>
		/// This creates a container based on the tagDef provided, and if null,
		/// then the container is made as a div, and with the attributes provided.
		/// </summary>
		/// <param name="tagDef"></param>
		/// <param name="attrs"></param>
		public HtmlContainer(string tagDef, params object[] attrs)
		{
			Container = (tagDef ?? "div").Attr(attrs);
		}

		/// <summary>
		/// Default implementation of the IHtmlRenderable interface which returns
		/// the Container, and should be overriden by derived classes.
		/// </summary>
		/// <returns></returns>
		public virtual IHtml ToHtml()
		{
			return Container;
		}

		/// <summary>
		/// The container rendered as Html.
		/// </summary>
		/// <returns>
		/// String representation of the Html.
		/// </returns>
		public override string ToString()
		{
			return Container.ToString();
		}
	}
}
