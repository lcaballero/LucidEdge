using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_DefaultHtmlFragmentStates : AssertionHelper
	{
		[Test]
		public void IsElement_Min()
		{
			var e = new Html { Name = "div" };

			Expect(e.IsElement);

			Expect(!e.IsText);
			Expect(!e.IsFragment);
		}

		[Test]
		public void IsAttribute_Min()
		{
			var e = new Html();
			e.Attr("id", "my-id");

			Expect(!e.IsElement);
			Expect(!e.IsText);
			Expect(!e.IsFragment);
		}

		[Test]
		public void IsText_Min()
		{
			var e = new Html { Value = "Here is some text." };

			Expect(e.IsText);

			Expect(!e.IsElement);
			Expect(!e.IsFragment);
		}

		[Test]
		public void IsFragment_Min()
		{
			var e = new Html();

			Expect(e.IsFragment);

			Expect(!e.IsText);
			Expect(!e.IsElement);
		}
	}
}
