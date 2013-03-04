using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LucidEdge.Html.ViewOrganization.Rendering;

namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public class AutoJsPackageAttribute : ActionFilterAttribute
	{
		public const string DefaultPackDirectory = "~/Content/ResourcePacks/";

		public string PackDirectory { get; set; }

		public AutoJsPackageAttribute() : this(DefaultPackDirectory) { }
		public AutoJsPackageAttribute(string dir)
		{
			PackDirectory = dir;
			Order = 10;
		}

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var controller = ActionParams.Instance.Controller;
			var action = ActionParams.Instance.Action;

			var file = PackFile(controller, action);

			if (File.Exists(file))
			{
				FilterActionItems.JavaScriptPackages.Add(file);
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
				string.Format("{0}.js.pack", action));
		}
	}
}
