using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LucidEdge.StringBuilding;


namespace LucidEdge.StringBuilding.Tests
{
	[TestFixture]
	public class Dupes : AssertionHelper
	{
		[Test]
		public void Dupes_S()
		{
			var buf = "*".Dupes(5);

			Expect(buf.ToString(), Is.EqualTo("*****"));
		}
	}
}
