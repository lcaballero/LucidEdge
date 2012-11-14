using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.StringBuilding.Tests
{
	[TestFixture]
	public class Test_Append_Lines : AssertionHelper
	{
		[Test]
		public void AppendLines_ES()
		{
			var b = new StringBuilder();
			var nl = Environment.NewLine;

			var items = new List<string> { "", "", "", "" };
			var buf = b.AppendLines(items).ToString();

			Expect(buf.ToString(), Is.EqualTo(nl+nl+nl+nl));
		}

		[Test]
		public void AppendAll_ES_Empty_Results()
		{
			var b = new StringBuilder();
			var nl = Environment.NewLine;

			var items = new List<string> { "", "", "", "" };
			var buf = b.AppendAll(items).ToString();

			Expect(buf.ToString(), Is.Empty);
		}

		[Test]
		public void AppendAll_ES_Embeded_Char()
		{
			var b = new StringBuilder();
			var nl = Environment.NewLine;

			var items = new List<string> { "", "1", "", "" };
			var buf = b.AppendAll(items).ToString();

			Expect(buf.ToString(), Is.EqualTo("1"));
		}

		[Test]
		public void AppendAll_ES_Embeded_Chars()
		{
			var b = new StringBuilder();
			var nl = Environment.NewLine;

			var items = new List<string> { "1", "2", "3", "4" };
			var buf = b.AppendAll(items).ToString();

			Expect(buf.ToString(), Is.EqualTo("1234"));
		}

		[Test]
		public void AppendAll_ES_T()
		{
			var b = new StringBuilder();
			var items = new List<int> { 1, 2, 3, 4 };
			var dict = items.ToDictionary(n => n, n => n * 2);

			var s = b.AppendAll(dict, (buf, n) => buf.AppendFormat("{0}={1}", n.Key, n.Value));

			Expect(s.ToString(), Is.EqualTo("1=22=43=64=8"));
		}
	}
}
