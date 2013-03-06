using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LucidEdge.Html.ViewOrganization.Rendering;

namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public class VirtualHomeAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			FilterActionItems.VirtualPathResolver =
				new VirtualPathResolver
				{
					HomePath = VirtualPathUtility.ToAbsolute("~/")
				};
		}
	}
}
