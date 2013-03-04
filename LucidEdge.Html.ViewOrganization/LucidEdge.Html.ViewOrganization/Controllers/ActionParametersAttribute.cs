using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LucidEdge.Html.ViewOrganization.Controllers.ActionFilters;

namespace LucidEdge.Html.ViewOrganization.Controllers
{
	public class ActionParametersAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			ActionParams.ActionParametersContextKey
				.Set<ActionParams>(
					new ActionParams
					{
						Context = filterContext
					});
		}
	}
}
