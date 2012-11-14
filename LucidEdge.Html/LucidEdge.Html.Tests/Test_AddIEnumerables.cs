using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_AddIEnumerables : AssertionHelper
	{
		public List<string> Nav()
		{
			return
			new List<string>
			{
				"Nav 1", "Nav 2", "Nav 3", "Nav 4", "Nav 5"
			};
		}

		[Test]
		public void Make_Unordered_List()
		{
			var ul = "ul".Add(Nav().Select(s => "li".Add(s)));

			Expect(ul.Children.Count == 5);
		}

		[Test]
		public void Make_Nested_IEnumerable()
		{
			var ul = "ul".Add(Nav().Select(s => "li".Add(s)));

			Expect(ul.ToString(), Is.EqualTo(
				@"<ul><li>Nav 1</li><li>Nav 2</li><li>Nav 3</li><li>Nav 4</li><li>Nav 5</li></ul>"));
		}

		[Test]
		public void Adding_Mulitple_Types()
		{
			var ul = 
				"div".Add(
					"Here are some things",
					"ul".Add(
						Nav().Select(s => "li".Add(s)),
						"li.last".Add("last")),
					"p".Add("The abstract"));

			Expect(ul.Children.Count == 3);
		}

		[Test]
		public void ToString_Mulitple_Types()
		{
			var ul =
				"div".Add(
					"Here are some things",
					"ul".Add(
						Nav().Select(s => "li".Add(s)),
						"li.last".Add("last")),
					"p".Add("The abstract"));

			Expect(ul.ToString(),
				Is.EqualTo(
				@"<div>Here are some things<ul><li>Nav 1</li><li>Nav 2</li><li>Nav 3</li><li>Nav 4</li><li>Nav 5</li><li class=""last"">last</li></ul><p>The abstract</p></div>"));
		}
	}
}
