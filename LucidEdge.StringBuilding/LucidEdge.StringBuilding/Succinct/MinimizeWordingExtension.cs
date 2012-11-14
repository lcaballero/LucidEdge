using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace LucidEdge.StringBuilding.Succinct
{
	public static class MinimizeWordingExtension
	{
		public static readonly Regex To_Regex = new Regex("->");

		public static List<Rule> ToRules(this string substitues, List<Rule> rules = null)
		{
			rules = rules ?? new List<Rule>();

			var lines = Substitutions.Rules.Split(
				"\r\n".ToCharArray(),
				StringSplitOptions.RemoveEmptyEntries);

			return
			lines.Select(sub => To_Regex.Split(sub))
				.Where(ab => ab.Length >= 2)
				.Select(ab => new Rule(ab.First(), ab.Last()))
				.OrderByDescending(r => r.Rank)
				.ToList();
		}

		public static string ToParagraph(this IEnumerable<string> lines)
		{
			return string.Join(" ", lines.ToArray());
		}

		public static List<Sentence> ToSentences(this string text)
		{
			string part = "";
			var result = new List<Sentence>();

			foreach (var c in text)
			{
				if (c == '.' || c == '?')
				{
					result.Add(new Sentence(part + c));
					part = "";
				}
				else
				{
					part += c;
				}
			}

			return result;
		}

		public static string RemoveWordiness(this IEnumerable<string> args)
		{
			return string.Join(" ", args.ToArray()).RemoveWordiness();
		}

		public static string RemoveWordiness(this string paragraph)
		{
			var sentences = paragraph.ToSentences().Process(Substitutions.Rules.ToRules());

			return "";
		}

		public static Sentence ApplyRule(this Sentence s, int pos, Rule r)
		{
			var length = r.Match.Length;
			var replacement = r.Replace;
			var text = pos > 0 ? s.Original : s.Text;

			var start = text.Substring(0, pos).TrimEnd();
			var end = text.Substring(pos + length).TrimStart();

			text = start + " " + replacement + " " + end;

			return new Sentence(text);
		}

		public static List<Sentence> Process(this List<Sentence> sentences, List<Rule> r)
		{
			return
			sentences
				.Select(s => s.Process(r))
				.ToList();
		}

		public static Sentence Process(this Sentence s, List<Rule> rules)
		{
			var text = s.Text.ToLower();
			int applied = 0;

			for (int i = 0; i < rules.Count; i++)
			{
				var r = rules[i];

				int offset = text.IndexOf(r.Match);

				if (offset >= 0)
				{
					s = s.ApplyRule(offset, r);
					text = s.Text;

					i = 0; // re-apply the rules
					applied++;
				}

				if (applied > 5) { break; }
			}

			return s;
		}
	}
}
