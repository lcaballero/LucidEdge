using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LucidEdge.Html;


namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_AddClass : AssertionHelper
	{
		[Test]
		public void Add_Class()
		{
			var d = "div".Add().AddClass("my-class");

			Expect(d.ToString(), Is.EqualTo("<div class=\"my-class\"/>"));
		}

		[Test]
		public void Add_One_Class()
		{
			var d = "div.first-class".Add().AddClass("my-class");

			Expect(d.ToString(), Is.EqualTo("<div class=\"first-class my-class\"/>"));
		}

		[Test]
		public void Add_Same_Class()
		{
			var d = "div.my-class".Add().AddClass("my-class");

			Expect(d.ToString(), Is.EqualTo("<div class=\"my-class\"/>"));
		}

		[Test]
		public void Add_Many_Classes()
		{
			var d = "div.a".AddClass("b").AddClass("c");

			Expect(d.ToString(), Is.EqualTo("<div class=\"a b c\"/>"));
		}
	}
}
