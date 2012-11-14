using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Html.Tests
{
	[Test_Fixture]
	public class Test_Add : AssertionHelper
	{
		[Test]
		public void Add_Numbers()
		{
			var d = "div".Add(1);

			Expect(d.IsElement);
			Expect(d.HasChildren);
			Expect(d.Children.Count == 1);
		}

		[Test]
		public void Add_Numbers_Child_Type()
		{
			var d = "div".Add(1);

			Expect(d.Children[0].IsText);
		}
	}
}
