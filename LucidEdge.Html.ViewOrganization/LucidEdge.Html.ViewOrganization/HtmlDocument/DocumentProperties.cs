using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LucidEdge.Html;


namespace LucidEdge.Html.ViewOrganization.HtmlDocument
{
	public class DocumentProperties
	{
		public const string DEFAULT_DOC_TYPE = "<!DOCTYPE html>";
		public string DocType { get; set; }
		public string Title { get; set; }

		public DocumentProperties()
		{
			DocType = DEFAULT_DOC_TYPE;
			Title = "";
		}
	}
}
