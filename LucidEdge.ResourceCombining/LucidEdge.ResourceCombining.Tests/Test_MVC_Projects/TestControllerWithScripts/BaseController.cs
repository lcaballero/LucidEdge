using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LucidEdge.Html.ViewOrganization.Controllers.ActionFilters;

namespace TestControllerWithScripts
{
	public class BaseController1 : System.Web.Mvc.Controller
	{
		[Scripts(
			"~/Content/Scripts/some-javascript-1.js",
			"~/Content/Scripts/some-javascript-2.js",
			"~/Content/Scripts/some-javascript-4.js")]
		public ActionResult Stuff()
		{
			return Content("");
		}
	}

	public class BaseController2 : System.Web.Mvc.Controller
	{
		[Scripts(
			"~/Content/Scripts/some-javascript-1.js",
			"~/Content/Scripts/some-javascript-3.js")]
		public ActionResult Stuff2()
		{
			return Content("");
		}
	}

	public class BaseController3 : System.Web.Mvc.Controller
	{
		[Scripts]
		public ActionResult Stuff2()
		{
			return Content("");
		}
	}
}
