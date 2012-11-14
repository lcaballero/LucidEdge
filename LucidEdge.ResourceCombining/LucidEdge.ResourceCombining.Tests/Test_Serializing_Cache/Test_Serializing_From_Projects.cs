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
	public class Test_Serializing_From_Projects : AssertionHelper
	{
		private ContentResolver ToMvcProjects()
		{
			return new ContentResolver
			{
				ContentDir = Path.Combine(
					Environment.CurrentDirectory,
					"../../Test_MVC_Projects/TestControllerWithScripts/").NormalizePath()
			};
		}

		private Assembly ToMvcProjectAssembly()
		{
			var dll = ToMvcProjects().ResolveUrl("~/bin/Debug/TestControllerWithScripts.dll");

			var a = Assembly.LoadFrom(dll);

			return a;
		}

		[Test]
		public void Serialize_From_Mvc_With_Scripts()
		{
			var ctr = ToMvcProjectAssembly()
				.FindControllers()
				.FindAttributes<ScriptsAttribute>()
				.ToCombinedResources(ToMvcProjects());

			var xml = ctr.Serialize();

			Console.WriteLine();
			Console.WriteLine(xml);

			Assert.Pass();
		}
	}
}
