using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.StringBuilding.Tests
{
	[TestFixture]
	public class DumpToVerbatim : AssertionHelper
	{
		[Test]
		public void Dump_RN()
		{
			string s = @"
";

			Expect(s.ToVerbatim(), Is.EqualTo("@" + "\r\n".ToQuoted()));
		}

		[Test]
		public void Dump_RN_T()
		{
			string s = @"
	Start Here
";
			Expect(s.ToVerbatim(), Is.EqualTo("@" + "\r\n\tStart Here\r\n".ToQuoted()));
		}

		[Test]
		public void Dump_N_T()
		{
			string s = "\n\tStart Here\n";

			Expect(s.ToVerbatim(), Is.EqualTo("@" + "\n\tStart Here\n".ToQuoted()));
		}

		[Test]
		public void Dump_RN_T_S_RN_T()
		{
			string s = @"
	Start Here
	\Next Line";

			Expect(s.ToVerbatim(), Is.EqualTo("@" + "\r\n\tStart Here\r\n\t\\Next Line".ToQuoted()));
		}
	}
}
