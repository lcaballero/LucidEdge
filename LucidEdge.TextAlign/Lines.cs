using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.TextAlign
{
	public static class LinesExtensions
	{
		public static double CalculateCost(List<string> words, int max_columns)
		{
			var d = words.Sum(s => s.Length) + words.Count - 1;
			var delta = max_columns - d;

			// Making negative values (> max_column) cost more
			return
				delta > 0 ? Math.Pow(delta * Math.PI, 2) :
				delta < 0 ? Math.Pow(delta * Math.PI, 4) :
				0;
		}

		public static Dictionary<int, List<Range>> Optimize(this List<string> words, int max_columns)
		{
			return
			(words.Count - 1).To(0)
				.SelectMany(i => FromLine(words, i, max_columns))
				.Aggregate(
					new Dictionary<int, List<Range>>(),
					(acc, r) =>
					{
						if (!acc.ContainsKey(r.EndWord))
						{
							acc[r.EndWord] = new List<Range>();
						}
						acc[r.EndWord].Add(r);
						r.EndToRanges = acc;

						return acc;
					});
		}

		public static List<Range> FromLine(List<string> words, int end_word, int max_columns)
		{
			List<Range> ranges = new List<Range>();

			for (int i = end_word; i >= 0; i--)
			{
				var range = new Range
				{
					EndWord = end_word,
					StartWord = i,
					LineCost = (m) => CalculateCost(m, max_columns),
					RawWords = words,
					MaxColumn = max_columns
				};

				ranges.Add(range);

				if (range.IsOverMaxColumns)
				{
					break;
				}
			}

			return ranges;
		}
	}

	public static class ToExtensions
	{
		public static IEnumerable<int> To(this int from, int to)
		{
			if ((to - from) > 0)
			{
				for (int i = from; i < to; i++)
				{
					yield return i;
				}
			}
			else
			{
				for (int i = from; i >= to; i--)
				{
					yield return i;
				}
			}
		}
	}
}

