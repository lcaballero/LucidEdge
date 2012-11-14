using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using LucidEdge.ResourceCombining;


namespace LucidEdge.ResourceCombining.Tests
{
	[TestFixture]
	public class Test_Assembly_Traversal : AssertionHelper
	{
		private ContentResolver ToMvcProjects()
		{
			return new ContentResolver
			{
				ContentDir = Path.Combine(
					Environment.CurrentDirectory,
					"../../Test_MVC_Projects/")
			};
		}

		[Test]
		public void Find_Controllers()
		{
			var dll = ToMvcProjects().ResolveUrl("~/TestOnlyControllers/bin/Debug/TestOnlyControllers.dll");

			var a = Assembly.LoadFrom(dll);

			var ctr = typeof(System.Web.Mvc.Controller).FindTypes(a).ToList();

			Expect(ctr.Count, Is.Not.Null);
			Expect(ctr.Count, Is.GreaterThan(0));
		}

		[Test]
		public void Find_Controllers_Names()
		{
			var dll = ToMvcProjects().ResolveUrl("~/TestOnlyControllers/bin/Debug/TestOnlyControllers.dll");

			var a = Assembly.LoadFrom(dll);

			var ctr = typeof(System.Web.Mvc.Controller).FindTypes(a)
				.First()
				.Select(c => c.Name)
				.ToList();

			var set = new HashSet<string>(ctr);

			Expect(set.Contains("BaseController1"));
			Expect(set.Contains("BaseController2"));
			Expect(set.Contains("BaseController3"));
		}
	}
}
