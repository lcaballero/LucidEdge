using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_BasicCreationTests : AssertionHelper
	{
		[Test]
		public void Add_Min()
		{
			var e = "div".Add();

			Expect(e.IsElement);
		}

		[Test]
		public void HasA()
		{
			var e = "div".Add();

			Expect(e.IsElement);
		}
	}
}
