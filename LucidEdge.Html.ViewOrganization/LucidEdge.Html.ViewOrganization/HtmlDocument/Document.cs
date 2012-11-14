using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LucidEdge.Html;


namespace LucidEdge.Html.ViewOrganization.HtmlDocument
{
	public interface IDocument : IHtmlRenderable
	{
		DocumentProperties Properties { get; set; }
		DocumentResources Resources { get; set; }
	}

	public abstract class Document : IDocument
	{
		public DocumentProperties Properties { get; set; }
		public DocumentResources Resources { get; set; }

		public IHtml Html { get; set; }
		public IHtml Head { get; set; }
		public IHtml Body { get; set; }
		public IHtmlRenderable Content { get; set; }

		public Document()
		{
			Properties = new DocumentProperties();

			Html = "html".Add();
			Body = "body".Add();
			Head = "head".Add();
		}

		public abstract IHtml ToHtml();
	}
}
