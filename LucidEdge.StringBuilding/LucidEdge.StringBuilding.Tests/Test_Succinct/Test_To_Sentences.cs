using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using LucidEdge.StringBuilding.Succinct;


namespace LucidEdge.StringBuilding.Tests.Succinct_Tests
{
	[TestFixture]
	public class Test_To_Sentences : AssertionHelper
	{
		[Test]
		public void To_Paragraph()
		{
			var file = "Files/Paragraphs-1.txt";

			var text = File.ReadAllText(file);
			text = text.Replace("\r\n", " ").Trim();

			var lines = File.ReadAllLines(file);

			var para = lines
				.Where(s => !string.IsNullOrEmpty(s.Trim()))
				.ToParagraph();

			Expect(para.Length == text.Length);
		}

		[Test]
		public void To_Sentences()
		{
			var file = "Files/Paragraphs-1.txt";
			var text = File.ReadAllText(file);
			var sentences = text.Trim().ToSentences();

			var periods = text
				.ToCharArray()
				.Where(c => c == '.')
				.ToArray();

			Expect(sentences.Count, Is.EqualTo(periods.Length));
		}

		[Test]
		public void To_Rules()
		{
			var rules = Substitutions.Rules.ToRules();

			Expect(rules.Count > 0);
		}
	}
}


