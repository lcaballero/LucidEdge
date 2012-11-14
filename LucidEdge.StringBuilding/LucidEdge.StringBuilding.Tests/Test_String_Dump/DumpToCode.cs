using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace LucidEdge.StringBuilding.Tests
{
	[TestFixture]
	public class DumpToCode : AssertionHelper
	{
		[Test]
		public void Dump_RN()
		{
			string s = @"
";

			Expect(s.ToCode(), Is.EqualTo("\\r\\n".ToQuoted()));
		}

		[Test]
		public void Dump_RN_T()
		{
			var nl = Environment.NewLine; 
			string s = @"
	Start Here
";
			Expect(s.ToCode(), Is.EqualTo("\\r\\n\\tStart Here\\r\\n".ToQuoted()));
		}

		[Test]
		public void Dump_N_T()
		{
			var nl = Environment.NewLine;
			string s = @"\n\tStart Here\n";

			Expect(s.ToCode(), Is.EqualTo("\\n\\tStart Here\\n".ToQuoted()));
		}

		[Test]
		public void Dump_RN_T_S_RN_T()
		{
			var nl = Environment.NewLine;
			string s = @"
	Start Here
	\Next Line";

			Expect(s.ToCode(), Is.EqualTo("\\r\\n\\tStart Here\\r\\n\\t\\Next Line".ToQuoted()));
		}
	}
}
