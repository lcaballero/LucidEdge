using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SimpleLineParser.Tests
{
	[TestFixture]
	public class ParseLinesTests : AssertionHelper
	{
		[Test]
		public void To_Lines_For_Null()
		{
			Expect("".ToLines().Count(), Is.EqualTo(0));
		}

		[Test]
		public void To_Lines_For_1_Line()
		{
			Expect("here is one line".ToLines().Count(), Is.EqualTo(1));
		}

		[Test]
		public void To_Lines_For_2_Line()
		{
			var text =
				@"here is one line
";

			Expect(text.ToLines().Count(), Is.EqualTo(1));
		}

		[Test]
		public void To_Lines_Starts_With_WS()
		{
			var text =
				@"

here is one line


";

			Expect(text.ToLines().Count(), Is.EqualTo(5));
		}

		[Test]
		public void To_Lines_All_WS()
		{
			var text =
				@"




";

			Expect(text.ToLines().Count(), Is.EqualTo(5));
		}

		[Test]
		public void Parse_All_WS()
		{
			var text =
				@"




";

			Expect(LinesReader.Parse(text).Count(), Is.EqualTo(0));
		}

		[Test]
		public void Parse_WS_And_1_Line()
		{
			var text =
				@"

text here.


";

			Expect(LinesReader.Parse(text).Count(), Is.EqualTo(1));
		}
	}
}
