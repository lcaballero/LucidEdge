using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.ResourceCombining.Tests
{
	[TestFixture]
	public class Test_Path_Normalization_Helpers : AssertionHelper
	{
		[Test]
		public void Normalize_Path_Empty_String()
		{
			var s = "".NormalizePath();

			Expect(s, Is.Not.Null);
			Expect(s.Length, Is.EqualTo(0));
		}

		[Test]
		public void Normalize_Path_Root()
		{
			var s = "/".NormalizePath();

			Expect(s, Is.Not.Null);
			Expect(s.Length, Is.EqualTo(1));
			Expect(s, Is.EqualTo("\\"));
		}

		[Test]
		[ExpectedException]
		public void Normalize_Path_Null()
		{
			string s = null;
			s.NormalizePath();
		}

		[Test]
		public void Normalize_Path_Content_Path()
		{
			string s = "~/Content/Scripts/jquery-1.0.js";
			var actual = s.NormalizePath();
			var expected = "~\\Content\\Scripts\\jquery-1.0.js";

			Expect(actual, Is.EqualTo(expected));
		}
	}
}
