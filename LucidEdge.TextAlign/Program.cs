using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.TextAlign
{
	public class Program
	{
		public const string Lines = @"
Ours was the marsh country, down by the river, within, as the river
wound, twenty miles of the sea. My first most vivid and broad impression
of the identity of things seems to me to have been gained on a memorable
raw afternoon towards evening. At such a time I found out for certain
that this bleak place overgrown with nettles was the churchyard; and
that Philip Pirrip, late of this parish, and also Georgiana wife of the
above, were dead and buried; and that Alexander, Bartholomew, Abraham,
Tobias, and Roger, infant children of the aforesaid, were also dead
and buried; and that the dark flat wilderness beyond the churchyard,
intersected with dikes and mounds and gates, with scattered cattle
feeding on it, was the marshes; and that the low leaden line beyond
was the river; and that the distant savage lair from which the wind was
rushing was the sea; and that the small bundle of shivers growing afraid
of it all and beginning to cry, was Pip.";

		public static void Main(string[] args)
		{
			var opt =
				Lines.Split("\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
					.ToList()
					.Optimize(80);

			var ns = (10).To(0).Select(n => n).ToList();
		}
	}
}
