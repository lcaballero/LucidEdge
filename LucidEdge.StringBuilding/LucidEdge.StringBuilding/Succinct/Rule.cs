using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LucidEdge.StringBuilding.Succinct
{
	public class Rule
	{
		public string Match { get; set; }
		public string Replace { get; set; }

		public int Rank { get { return Match.Length; } }

		public Rule(string match, string replace)
		{
			Match = match.Trim();
			Replace = replace.Trim();
		}

		public override string ToString()
		{
			return string.Format("{0} -> {1}", Match, Replace);
		}
	}
}