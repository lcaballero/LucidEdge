using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Html.Tests
{
	[Test_Fixture]
	public class Test_ToNodes : AssertionHelper
	{
		[Test]
		public void Number_ToNodes()
		{
			var nodes = (1).ToNodes();

			Expect(nodes, Is.Not.Null);
			Expect(nodes.FirstOrDefault(), Is.Not.Null);
			Expect(nodes.FirstOrDefault().IsText);
		}

		[Test]
		public void Number_ToNodes_ToString()
		{
			var nodes = (1).ToNodes();

			Expect(nodes.First().ToString(), Is.EqualTo("1"));
		}

		[Test]
		public void String_ToNodes()
		{
			var nodes = ("some string").ToNodes();

			Expect(nodes, Is.Not.Null);
			Expect(nodes.FirstOrDefault(), Is.Not.Null);
			Expect(nodes.FirstOrDefault().IsText);
		}

		[Test]
		public void String_List_ToNodes()
		{
			var text = new List<string> { "some string 1", "some string 1" };
			var nodes = text.ToNodes();

			Expect(nodes, Is.Not.Null);
			Expect(nodes.Count(), Is.GreaterThan(0));
			Expect(nodes.All(n => n.IsText));
		}

		[Test]
		public void Null_ToNodes()
		{
			var nodes = ((object)null).ToNodes();

			Expect(nodes, Is.Not.Null);
			Expect(nodes.Count(), Is.EqualTo(0));
		}
	}
}
