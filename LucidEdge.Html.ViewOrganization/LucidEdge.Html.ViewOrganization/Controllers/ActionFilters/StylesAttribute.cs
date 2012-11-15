using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public sealed class StylesAttribute : ResourceCollectionAttribute
	{
		public StylesAttribute(params string[] paths)
			: base(paths) { }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			FilterActionItems.Styles.AddRange(Paths);
		}
	}
}
