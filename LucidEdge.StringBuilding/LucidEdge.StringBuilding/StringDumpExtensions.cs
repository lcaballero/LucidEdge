using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.StringBuilding
{
	public static class StringDumpExtensions
	{
		public static StringBuilder ToStringEscapes(StringBuilder buf, char c)
		{
			switch (c)
			{
				case '\r':
					return buf.Append('\\').Append('r');
				case '\n':
					return buf.Append('\\').Append('n');
				case '\t':
					return buf.Append('\\').Append('t');
				default:
					return buf.Append(c);
			}
		}

		public static StringBuilder ToVerbatimEscapes(StringBuilder buf, char c)
		{
			switch (c)
			{
				case '"':
					return buf.Append('"').Append('"');
				default:
					return buf.Append(c);
			}
		}

		public static string ToCode(this string s)
		{
			return
			s.Aggregate(
					new StringBuilder("\"", s.Length * 2),
					ToStringEscapes)
				.Append("\"")
				.ToString();
		}

		public static string ToVerbatim(this string s)
		{
			return
			s.Aggregate(
					new StringBuilder("@\"", s.Length * 2),
					ToVerbatimEscapes)
				.Append("\"")
				.ToString();
		}

		public static string ToQuoted(this string s)
		{
			return "\"" + s + "\"";
		}
	}
}
