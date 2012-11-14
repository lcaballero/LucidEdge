using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using System.Reflection;
using LucidEdge.Html.ViewOrganization.Controllers.ActionFilters;

namespace LucidEdge.ResourceCombining.Tests
{
	[TestFixture]
	public class Test_Attribute_Finding : AssertionHelper
	{
		private ContentResolver ToMvcProjects()
		{
			return new ContentResolver
			{
				ContentDir = Path.Combine(
					Environment.CurrentDirectory,
					"../../Test_MVC_Projects/").NormalizePath()
			};
		}

		private Assembly ToMvcProjectAssembly()
		{
			var dll = ToMvcProjects().ResolveUrl("~/TestControllerWithScripts/bin/Debug/TestControllerWithScripts.dll");

			var a = Assembly.LoadFrom(dll);

			return a;
		}

		private Assembly ToMvcProjectAssembly2()
		{
			var dll = ToMvcProjects().ResolveUrl("~/TestOnlyControllers/bin/Debug/TestOnlyControllers.dll");

			var a = Assembly.LoadFrom(dll);

			return a;
		}


		[Test]
		public void Find_Multiple_Assemblies()
		{
			var ctr =
				typeof(System.Web.Mvc.Controller)
				.FindTypes(
					ToMvcProjectAssembly(),
					ToMvcProjectAssembly2())
				.FindAttributes<ScriptsAttribute>()
				.ToList();

			Expect(ctr, Is.Not.Null);
			Expect(ctr.Count, Is.EqualTo(2));
		}

		[Test]
		public void Find_Scripts_Single_Assembly()
		{
			var ctr = ToMvcProjectAssembly()
				.FindControllers()
				.FindAttributes<ScriptsAttribute>()
				.ToList();

			Expect(ctr, Is.Not.Null);
			Expect(ctr.Count, Is.EqualTo(1));
		}

		[Test]
		public void Find_Scripts_Attributes()
		{
			var ctr = typeof(System.Web.Mvc.Controller)
				.FindTypes(ToMvcProjectAssembly())
				.FindAttributes<ScriptsAttribute>()
				.ToList();

			Expect(ctr, Is.Not.Null);
			Expect(ctr.Count, Is.GreaterThan(0));
		}

		[Test]
		public void Find_Scripts_Attributes_Paths()
		{
			var ctr = ToMvcProjectAssembly()
				.FindControllers()
				.FindAttributes<ScriptsAttribute>()
				.First()
				.SelectMany(p => p.Paths)
				.ToList();

			Expect(ctr, Is.Not.Null);
			Expect(ctr.Count, Is.GreaterThan(0));
		}

		[Test]
		public void Find_Path_To_Actions()
		{
			var ctr = ToMvcProjectAssembly()
				.FindControllers()
				.FindAttributes<ScriptsAttribute>()
				.First()
				.ToDictionary(
					p => string.Format("~/{0}/{1}", p.Controller.Name, p.Method.Name),
					p => p.Paths);

			Expect(ctr, Is.Not.Null);
			Expect(ctr.ContainsKey("~/BaseController1/Stuff"));
			Expect(ctr.ContainsKey("~/BaseController2/Stuff2"));
			Expect(ctr.ContainsKey("~/BaseController3/Stuff2"));
		}

		[Test]
		public void Find_Paths_With_Actions()
		{
			var ctr = ToMvcProjectAssembly()
				.FindControllers()
				.FindAttributes<ScriptsAttribute>()
				.First()
				.ToDictionary(
					p => string.Format("~/{0}/{1}", p.Controller.Name, p.Method.Name),
					p => p.Paths);

			Expect(ctr, Is.Not.Null);
			Expect(ctr["~/BaseController1/Stuff"].Count, Is.EqualTo(3));
			Expect(ctr["~/BaseController2/Stuff2"].Count, Is.EqualTo(2));
			Expect(ctr["~/BaseController3/Stuff2"].Count, Is.EqualTo(0));
		}

		[Test]
		public void Find_Action_Paths()
		{
			var cr = 
				new ContentResolver
				{
					ContentDir = Path.Combine(
							Environment.CurrentDirectory,
							"../../Test_MVC_Projects/TestControllerWithScripts/")
						.NormalizePath()
				};

			var ctr = ToMvcProjectAssembly()
				.FindControllers()
				.FindAttributes<ScriptsAttribute>()
				.CombineFiles(cr)
				.First()
				.ToDictionary(p => p.ActionPath, p => p.Paths);

			Expect(ctr, Is.Not.Null);
			Expect(ctr["~/BaseController1/Stuff"].Count, Is.EqualTo(3));
			Expect(ctr["~/BaseController2/Stuff2"].Count, Is.EqualTo(2));
			Expect(ctr["~/BaseController3/Stuff2"].Count, Is.EqualTo(0));
		}


		[Test]
		public void Caches_Per_Action_Single_Assembly()
		{
			var cr =
				new ContentResolver
				{
					ContentDir = Path.Combine(
							Environment.CurrentDirectory,
							"../../Test_MVC_Projects/TestControllerWithScripts/")
						.NormalizePath()
				};

			var ctr = ToMvcProjectAssembly()
				.FindControllers()
				.FindAttributes<ScriptsAttribute>()
				.ToCombinedResources(cr);

			Expect(ctr, Is.Not.Null);
			Expect(ctr.Caches.Count, Is.EqualTo(3));
		}

		[Test]
		public void Caches_Per_Action_Multiple_Assembly()
		{
			var cr =
				new ContentResolver
				{
					ContentDir = Path.Combine(
							Environment.CurrentDirectory,
							"../../Test_MVC_Projects/TestControllerWithScripts/")
						.NormalizePath()
				};

			var ctr =
				typeof(System.Web.Mvc.Controller)
				.FindTypes(
					ToMvcProjectAssembly(),
					ToMvcProjectAssembly2())
				.FindAttributes<ScriptsAttribute>()
				.ToCombinedResources(cr);

			Expect(ctr, Is.Not.Null);
			Expect(ctr.Caches.Count, Is.EqualTo(3));
		}
	}
}
