using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public class JavaScriptPackageAttribute : ResourceCollectionAttribute
	{
		public JavaScriptPackageAttribute(params string[] paths)
			: base(paths) { }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			FilterActionItems.JavaScriptPackages.AddRange(Paths);
		}
	}
}
