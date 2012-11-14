using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;


namespace LucidEdge.StringBuilding.Succinct
{
	public class Sentence
	{
		public string Text { get; set; }
		public string Original { get; set; }

		public Sentence(string text)
		{
			Original = text;
			Text = text.ToLower();
		}
	}
}
