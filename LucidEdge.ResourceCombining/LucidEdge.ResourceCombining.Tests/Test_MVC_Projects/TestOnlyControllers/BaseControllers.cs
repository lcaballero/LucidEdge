using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TestOnlyControllers
{
	public class BaseController1 : System.Web.Mvc.Controller
	{
		public ActionResult Stuff()
		{
			return Content("");
		}
	}

	public class BaseController2 : System.Web.Mvc.Controller
	{
		public ActionResult Stuff2()
		{
			return Content("");
		}
	}

	public class BaseController3 : System.Web.Mvc.Controller
	{
		public ActionResult Stuff2()
		{
			return Content("");
		}
	}
}
