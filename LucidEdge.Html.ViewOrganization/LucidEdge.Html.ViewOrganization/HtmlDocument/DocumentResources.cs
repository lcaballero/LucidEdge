using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace LucidEdge.Html.ViewOrganization.HtmlDocument
{
	public class DocumentResources
	{
		public virtual List<string> CombinedCss { get; set; }
		public virtual List<string> CombinedJs { get; set; }
		public virtual Func<string> OnDocumentReadyCode { get; set; }
		public virtual string ResourceDirectory { get; set; }
	}
}
