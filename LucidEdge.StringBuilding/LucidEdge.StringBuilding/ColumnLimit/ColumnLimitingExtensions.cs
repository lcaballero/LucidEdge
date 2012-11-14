using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace LucidEdge.StringBuilding.ColumnLimit
{
	public static class ColumnLimitingExtensions
	{
		private static string[] ToTokens(this string para)
		{
			return para.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		}

		private static string NormalizeArgs(this IEnumerable<string> args)
		{
			return string.Join(" ", args.ToArray());
		}

		public static string ToParagraph(this string para, int n)
		{
			return para.ToTokens().ToParagraph(n);
		}

		public static string ToParagraph(this IEnumerable<string> args, int n)
		{
			// This is done because some of the args passed to Main might
			// be quoted strings and instead need to be joined together.
			var text = args.NormalizeArgs();
			var tokens = text.ToTokens().ToList();
			var lines = tokens.ToParagraph(n);

			return lines.ToParagraph(n).ToString();
		}

		private static readonly Regex LineEndings = new Regex("\r\n|\n", RegexOptions.Multiline);

		public static string[] ToLines(this string s)
		{
			return LineEndings.Split(s);
		}

		public static int LineWidth(this IEnumerable<string> tokens)
		{
			return
			tokens.Aggregate(
				0, (acc, token) => acc += token.Length + 1) - 1;
		}

		private static List<List<string>> ToParagraph(this List<string> tokens, int n)
		{
			var lines = new List<List<string>>();
			var line = new List<string>();

			for (int i = 0; i < tokens.Count; i++)
			{
				var last_token = tokens[i];
				var line_width = line.LineWidth() + last_token.Length;

				if (line_width < n)
				{
					line.Add(last_token);
				}
				else
				{
					lines.Add(line);
					line = new List<string> { last_token };
				}

				if (i == tokens.Count - 1)
				{
					if (line_width <= n)
					{
						lines.Add(line);
					}
					else
					{
						lines.Add(new List<string> { last_token });
					}
				}
			}

			return lines;
		}

		private static string ToParagraph(this List<List<string>> lines, int n)
		{
			var all = string.Join("\n",
				lines.Select(tokens => string.Join(" ", tokens.ToArray()))
					.ToArray());

			return all;
		}
	}
}
