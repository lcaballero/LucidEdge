using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace LucidEdge.ResourceCombining.Tests
{
	[TestFixture]
	public class Test_ResolvePaths : AssertionHelper
	{
		[Test]
		public void Resolve_To_Files_Set()
		{
			var root = Environment.CurrentDirectory + "../../Conbining_Files_Sets/";
			root = Path.GetFullPath(root);

			var cr = new ContentResolver { ContentDir = root };

			var actual = cr.ResolveUrl("~/Stuff.js").NormalizePath();
			var expected = Path.Combine(root.WithPathEnd(), "Stuff.js");

			Expect(actual, Is.EqualTo(expected));
		}

		[Test]
		[ExpectedException]
		public void Resolve_Null()
		{
			string s = null;

			var cr = new ContentResolver { ContentDir = "C:\\" };

			var actual = cr.ResolveUrl(s);
		}

		[Test]
		public void No_Home_Tilda()
		{
			var cr = new ContentResolver { ContentDir = "C:\\" };

			var actual = cr.ResolveUrl("/Stuff.js").NormalizePath();

			var expected = "\\Stuff.js";

			Expect(actual, Is.EqualTo(expected));
		}
	}
}
