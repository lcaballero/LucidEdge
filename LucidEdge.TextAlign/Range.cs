using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.TextAlign
{
	public class Range
	{
		public int StartWord { get; set; }
		public int EndWord { get; set; }
		public int MaxColumn { get; set; }

		public Func<List<string>, double> LineCost { get; set; }
		public double Cost { get { return LineCost(Words); } }

		public List<string> RawWords { get; set; }

		public Dictionary<int, List<Range>> EndToRanges { get; set; }

		public int Columns { get { return Line.Length; } }
		public bool IsOverMaxColumns { get { return Columns < MaxColumn; } }

		public List<string> Words
		{
			get
			{
				return
				RawWords
					.Where((s, n) => n >= StartWord && n <= EndWord)
					.ToList();
			}
		}

		public string Line
		{
			get
			{
				return
				string.Join(" ", Words.ToArray()) + Environment.NewLine;
			}
		}
	}
}
