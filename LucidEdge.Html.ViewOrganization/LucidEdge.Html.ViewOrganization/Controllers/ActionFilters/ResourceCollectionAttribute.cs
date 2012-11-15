using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public class ResourceCollectionAttribute : ActionFilterAttribute
	{
		public List<string> Paths { get; set; }

		public ResourceCollectionAttribute(params string[] srcs)
		{
			Paths = srcs.ToList();
		}
	}
}
