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

	public class InlineScriptsAttribute : ResourceCollectionAttribute
	{
		public InlineScriptsAttribute(params string[] paths)
			: base(paths) { }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			FilterActionItems.Inlines.AddRange(Paths);
		}
	}

	public class ScriptsAttribute : ResourceCollectionAttribute
	{
		public ScriptsAttribute(params string[] paths)
			: base(paths) { }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			FilterActionItems.Scripts.AddRange(Paths);
		}
	}

	public sealed class StylesAttribute : ResourceCollectionAttribute
	{
		public StylesAttribute(params string[] paths)
			: base(paths) { }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			FilterActionItems.Styles.AddRange(Paths);
		}
	}

	public class JavaScriptPackageAttribute : ResourceCollectionAttribute
	{
		public JavaScriptPackageAttribute(params string[] paths)
			: base(paths) { }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			FilterActionItems.JavaScriptPackages.AddRange(Paths);
		}
	}

	public class StylesheetPackageAttribute : ResourceCollectionAttribute
	{
		public StylesheetPackageAttribute(params string[] paths)
			: base(paths) { }

		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			FilterActionItems.StylesheetPackages.AddRange(Paths);
		}
	}
}
