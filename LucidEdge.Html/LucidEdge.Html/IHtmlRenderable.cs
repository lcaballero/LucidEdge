using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.Html
{
	/// <summary>
	/// Objects that implement IHtmlRenderable are able to render themselves
	/// as IHtml objects (Elements, Fragments, or Text Nodes).
	/// </summary>
	public interface IHtmlRenderable
	{
		IHtml ToHtml();
	}
}
