using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public class AutoCssPackageAttribute : ActionFilterAttribute
	{
		public const string DefaultPackDirectory = "~/Content/ResourcePacks/";

		public string PackDirectory { get; set; }
		public ActionParams Params { get; set; }

		public AutoCssPackageAttribute() : this(DefaultPackDirectory) { }
		public AutoCssPackageAttribute(string dir)
		{
			PackDirectory = dir;
			Order = 10;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			Params = new ActionParams { Context = filterContext };

			var controller = Params.Controller;
			var action = Params.Action;

			var file = PackFile(controller, action);

			if (File.Exists(file))
			{
				FilterActionItems.StylesheetPackages.Add(file);
			}
		}

		private bool HasPackFile(string controller, string action)
		{
			return
			File.Exists(
				PackFile(controller, action));
		}

		private string PackFile(string controller, string action)
		{
			return
			Path.Combine(
				FilterActionItems.HomeResolver.ResolveUrl(PackDirectory),
				controller,
				string.Format("{0}.css.pack", action));
		}
	}
}
