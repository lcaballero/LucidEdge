using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.TextAlign
{
	public class Pair
	{
		public int Row { get; set; }
		public int Column { get; set; }
		public int Alphas { get; set; }
		public int Deltas { get; set; }

		public Pair From { get; set; }
	}

	public static class Match
	{
		public static string To(string text, Func<char, string> a, Func<char, string> b)
		{
			return null;
		}

		public static string Init(Func<char, string> a, Func<char, string> b)
		{
			return null;
		}

		public static List<string> MinimalCost(string raw, string fin)
		{
			if (string.IsNullOrEmpty(raw))
			{
				return new List<string>();
			}
			else if (string.IsNullOrEmpty(fin))
			{
				return new List<string>();
			}

			return null;
		}

		public static List<string> AlignPairs(string raw, string fin)
		{
			return null;
		}

		public static List<Pair> MinimulAlignmentCost(string raw, string fin)
		{
			int m = raw.Length;
			int n = fin.Length;

			InitializePairList(m + 1, n + 1);
			return null;
		}

		public static List<string> OptimalAlignment(
			Func<int, double> alphaCost, Func<int, double> deltaCost,
			List<List<Pair>> pairs,
			int i, int j,
			string raw, string fin)
		{
			char c1 = raw[i - 1];
			char c2 = fin[j - 1];

			Pair p1 = pairs[i - 1][j - 1];
			double d1 = (c1 == c2)
				? AlignmentCost(alphaCost, deltaCost, p1.Alphas, p1.Deltas, c1, c2)
				: double.MaxValue;

			Pair p2 = pairs[i - 1][j];
			double d2 = AlignmentCost(alphaCost, deltaCost, p2.Alphas, p2.Deltas, c1, c2);

			Pair p3 = pairs[i][j - 1];
			double d3 = AlignmentCost(alphaCost, deltaCost, p3.Alphas, p3.Deltas, c1, c2);

			Pair p = pairs[i][j];

			if (d1 <= d2 && d1 <= d3)
			{
				p.From = p1;
				p.Deltas = p1.Deltas;
				p.Alphas = p1.Alphas;
			}
			else if (d2 <= d1 && d2 <= d3)
			{
				p.From = p2;
				p.Deltas = p2.Deltas + 1;
				p.Alphas = p2.Alphas;
			}
			else
			{
				p.From = p3;
				p.Deltas = p3.Deltas;
				p.Alphas = p3.Alphas + 1;
			}

			return null;
		}

		private static double AlignmentCost(
			Func<int, double> alphaCost,
			Func<int, double> deltaCost,
			int alphas,
			int deltas,
			char c1,
			char c2)
		{
			return alphaCost(alphas) + deltaCost(deltas);
		}

		public static List<List<Pair>> InitializePairList(int m, int n)
		{
			var pairs = CreatePairList(m, n);

			for (int i = 1; i < m; i++)
			{
				var p = pairs[i][0];
				p.Deltas = i;

				if (i > 0)
				{
					p.From = pairs[i - 1][0];
				}
			}

			for (int i = 1; i < n; i++)
			{
				var p = pairs[0][i];
				p.Alphas = i;

				if (i > 0)
				{
					p.From = pairs[0][i - 1];
				}
			}

			return pairs;
		}

		public static List<List<Pair>> CreatePairList(int m, int n)
		{
			var pairs = new List<List<Pair>>();

			for (int i = 0; i < m; i++)
			{
				var row = new List<Pair>();

				pairs.Add(row);

				for (int j = 0; j < n; i++)
				{
					row.Add(
						new Pair
						{
							Row = i,
							Column = j,
							Alphas = 0,
							Deltas = 0
						});
				}
			}

			return pairs;
		}
	}
}
