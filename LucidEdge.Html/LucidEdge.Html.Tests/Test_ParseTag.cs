using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_ParseTag : AssertionHelper
	{
		[Test]
		public void ParseTag_Div()
		{
			var tag = "div".ParseTag();

			Expect(tag, Is.EqualTo("div"));
		}

		[Test]
		public void ParseTag_Span()
		{
			var tag = "span".ParseTag();

			Expect(tag, Is.EqualTo("span"));
		}

		[Test]
		public void ParseTag_Empty()
		{
			var tag = "".ParseTag();

			Expect(tag, Is.EqualTo("div"));
		}

		[Test]
		public void ParseTag_Span_Id()
		{
			var tag = "span#my-id".ParseTag();

			Expect(tag, Is.EqualTo("span"));
		}

		[Test]
		public void ParseTag_Empty_Id()
		{
			var tag = "#my-id".ParseTag();

			Expect(tag, Is.EqualTo("div"));
		}

		[Test]
		public void ParseTag_Strong_Class()
		{
			var tag = "strong.my-class".ParseTag();

			Expect(tag, Is.EqualTo("strong"));
		}

		[Test]
		public void ParseTag_Empty_Class()
		{
			var tag = ".my-class".ParseTag();

			Expect(tag, Is.EqualTo("div"));
		}
	}
}
