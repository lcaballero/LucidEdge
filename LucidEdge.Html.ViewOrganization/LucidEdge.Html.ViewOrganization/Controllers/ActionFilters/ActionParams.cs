using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using LucidEdge.Html.ViewOrganization.Controllers.ActionFilters;


namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public class ActionParams
	{
		public const string ActionParametersContextKey = "ActionParametersContextKey";

		public ActionExecutingContext Context { get; set; }

		public static ActionParams Instance
		{
			get
			{
				var ctx = ActionParametersContextKey.Get<ActionParams>();

				if (ctx == null || ctx.Context == null)
				{
					throw new ArgumentException(
						@"Could not find a valid ActionParams object with context.
						Make sure there is an ActionParametersAttribute on the
						controller or on a parent (base) controller in order for
						that attribute to establish the ActionParams object in
						HttpContext for the request.");
				}

				return ctx;
			}
		}

		public RouteData RouteData
		{
			get { return Context.RequestContext.RouteData; }
		}

		public string Controller
		{
			get { return (RouteData.Values["controller"] ?? "").ToString(); }
		}

		public string Action
		{
			get { return (RouteData.Values["action"] ?? "").ToString(); }
		}
	}
}
