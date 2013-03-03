using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LucidEdge.Html.ViewOrganization.Rendering;


namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public class HomePathAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var home = filterContext.HttpContext.Server.MapPath("~/");

			FilterActionItems.HomeResolver =
				new AppHomePathResolver
				{
					HomePath = home
				};
		}
	}
}
