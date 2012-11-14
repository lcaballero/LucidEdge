using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Arguments.MapBuilder.Tests
{
	[TestFixture]
	public class Test_Args_Map_Building : AssertionHelper
	{
		[Test]
		public void Default_Values()
		{
			var args = new Args();

			Expect(args.IsRoot);
		}

		[Test]
		public void Result_Row_Key()
		{
			var args = new Args();
			var a = args[0][0]["Field"];

			Expect(a.ToString(), Is.EqualTo("0.0.Field"));
		}

		[Test]
		public void Only_Key()
		{
			var args = new Args();
			var a = args["Field"];

			Expect(a.ToString(), Is.EqualTo("Field"));
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void Should_Non_Accept_Null_Entry()
		{
			var a = new Args()[null];
		}
	}
}
