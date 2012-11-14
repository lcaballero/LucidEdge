using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public sealed class InlineModuleAttribute : ActionFilterAttribute
	{
		public List<Type> InlineModules { get; set; }

		public InlineModuleAttribute(params Type[] modules)
		{
			InlineModules = modules.ToList();
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			FilterActionItems.InlineModules.AddRange(InlineModules);
		}
	}
}
