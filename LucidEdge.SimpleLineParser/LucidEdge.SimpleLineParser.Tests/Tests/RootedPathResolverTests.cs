using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SimpleLineParser.Tests
{
	[TestFixture]
	public class RootedPathResolverTests : AssertionHelper
	{
		[Test]
		public void Maps_Path_To_Home_Rooted_Directory()
		{
			var r = new HomePathResolver("~/Home/");

			Expect(r.ResolvePath("~/File.txt"), Is.EqualTo("~/Home/File.txt"));
		}

		[Test]
		public void Maps_Path_Drive_Rooted_Directory()
		{
			var r = new HomePathResolver("C:\\Home\\");

			Expect(r.ResolvePath("~/File.txt"), Is.EqualTo("C:\\Home\\File.txt"));
		}

		[Test]
		public void Correctly_Handles_Extra_Dir_Forward_Slash()
		{
			var r = new HomePathResolver("/Home/");

			Expect(r.ResolvePath("/File.txt"), Is.EqualTo("/File.txt"));
		}

		[Test]
		public void Safely_Maps_Null()
		{
			var r = new HomePathResolver("/Home");

			Expect(r.ResolvePath(null), Is.EqualTo(""));
		}

		[Test]
		[ExpectedException]
		public void Null_Passed_To_Resolver_Constructor_Exception()
		{
			var r = new HomePathResolver(null);
		}
	}
}
