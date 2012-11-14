using System.Collections.Generic;
using System.Linq;
using LucidEdge.Html.ViewOrganization.HtmlDocument;


namespace LucidEdge.Html.ViewOrganization.Rendering.DocTypes
{
	public static class DocTypeExtensions
	{
		public static string ToDocType(this IDocument doc)
		{
			return
			doc.Properties != null
			&& !string.IsNullOrEmpty(doc.Properties.DocType)
				? doc.Properties.DocType
				: DocumentProperties.DEFAULT_DOC_TYPE;
		}

		public static string ToDocType(this DocumentProperties properties)
		{
			return
			properties != null
			&& !string.IsNullOrEmpty(properties.DocType)
				? properties.DocType
				: DocumentProperties.DEFAULT_DOC_TYPE;
		}
	}
}