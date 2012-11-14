using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LucidEdge.Html.ViewOrganization.HtmlDocument;
using LucidEdge.Html.ViewOrganization.Rendering.DocTypes;


namespace LucidEdge.Html.ViewOrganization.Controllers
{
	public class DefaultController : Controller
	{
		public virtual ActionResult Content(IDocument document)
		{
			Response.Write(document.ToDocType());
			Response.Write("\n\n");

			return Content(document.ToHtml().ToString());
		}
	}
}
