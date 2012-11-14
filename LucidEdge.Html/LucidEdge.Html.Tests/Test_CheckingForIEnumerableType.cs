using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_CheckingForIEnumerableType : AssertionHelper
	{
		[Test]
		public void Testing_Is_IEnumerable_Instance()
		{
			var d = new List<IHtml>
			{
				"div".Add()
			};

			Expect(d is IEnumerable<IHtml>);
		}
	}
}
