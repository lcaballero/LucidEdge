using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SimpleLineParser.Tests
{
	[TestFixture]
	public class LinesReaderTests : AssertionHelper
	{
		[Test]
		public void Null_Line_Is_Not_Comment_Line()
		{
			Expect(!((string)null).IsCommentLine());
		}

		[Test]
		public void Empty_Line_Is_Not_Comment_Line()
		{
			Expect(!"".IsCommentLine());
		}

		[Test]
		public void Lines_String_Is_Not_Empty_Line()
		{
			Expect(!"\t   \n \t".IsEmptyLine());
		}

		[Test]
		public void WS_String_Is_Empty_Line()
		{
			Expect("\t  \t".IsEmptyLine());
		}

		[Test]
		public void Spaced_String_Is_Empty_Line()
		{
			Expect("    ".IsEmptyLine());
		}

		[Test]
		public void Empty_String_Is_Empty_Line()
		{
			Expect("".IsEmptyLine());
		}

		[Test]
		public void Comment_Does_Not_Start_At_Column_1()
		{
			Expect("   # Comment that doesn't start at column 1".IsCommentLine());
		}

	}
}
