using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using LucidEdge.StringBuilding.ColumnLimit;


namespace LucidEdge.StringBuilding.Tests.ColumnLimit_Tests
{
	[TestFixture]
	public class Test_Column_Limits : AssertionHelper
	{
		public const string Sample = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
		public const string Sample_2 = "Here is some text that I want to buffer at the olumn 80 mark. Here is some text that I want to buffer at the olumn 80 mark.Here is some text that I want to buffer at the olumn 80 mark.Here is some text that I want to buffer at the olumn 80 mark.Here is some text that I want to buffer at the olumn 80 mark.";
		public const string Sample_3 = "Aliens or humans in the distant future live in a culture where worlds in the known Kingdom use war as a means to further the entire race's evolution.  The thinking is that tactical, strategic thinking, leadership etc. requires deep understanding in order to protect the entire race against the 'survival of the fittest' in a Darwinian universe.  What this means to the ruling bodies, and what has become tradition in the ruling houses, is that their race must train in every way possible.  They must learn the old war teachings, the old philosophies on fighting, from birth to adulthood.  At a reasonable age everyone learns war games, and physical combat skills from every possible teacher.  And since they have nearly conquered death, that is their life spans have increased to roughly 800 years then at about 170 years of training and education, etc they enter the accademy.  Once they have passed the accademy they return home and they engage in the real thing -- war with the other clans men.  They form alliances and forge bonds, and make war under the eyes of Artificial Intelligence that records and learns from the engagements.  To the victor's go not the spoils but the honor of raising their families and clans to a new level of the ruling body -- that is they were princes before but now they are something more.  Kings perhaps.";

		public const string Single_Line = "Files/Single-Line.txt";
		public const string Single_Line_After = "Files/Single-Line-After.txt";

		public const string Lines_2 =
@"1
  2";
		public const string Lines_5 = @"
1
2
";

		[Test]
		public void Limits()
		{
			var text = File.ReadAllText(Single_Line);
			var tokens = text.Split(
				" ".ToCharArray(),
				StringSplitOptions.RemoveEmptyEntries);

			int col = 80;

			var lines = tokens.ToParagraph(col).ToLines();

			Expect(lines.Length > 0);
			Expect(lines.All(a => a.Length <= col));
		}

		[Test]
		public void ToLines_2()
		{
			var txt = Lines_2.ToLines();

			Expect(txt.Length, Is.EqualTo(2));
		}

		[Test]
		public void ToLines_5()
		{
			var txt = Lines_5.ToLines();

			Expect(txt.Length, Is.EqualTo(4));
		}

		[Test]
		public void All_Column_Limited()
		{
			var full_line = File.ReadAllText("Files/Single-Line.txt");

			var para_lines = full_line.ToParagraph(80).ToLines()
				.Select(p => p.Trim())
				.ToList();

			Expect(para_lines.All(p => p.Length <= 80));
		}

		[Test]
		public void Compare_Lines()
		{
			var full_line = File.ReadAllText("Files/Single-Line.txt");

			var after_lines = File.ReadAllLines("Files/Single-Line-After.txt")
				.Select(p => p.Trim())
				.ToList();

			var para_lines = full_line.ToParagraph(76).ToLines()
				.Select(p => p.Trim())
				.ToList();

			var isSeq = after_lines.SequenceEqual(para_lines);

			if (!isSeq)
			{
				Console.WriteLine("\nAfter Lines:\n");
				after_lines.ForEach(
					line => Console.WriteLine(line));

				Console.WriteLine("\nPara Lines:\n");
				para_lines.ForEach(
					line => Console.WriteLine(line));
			}

			Expect(isSeq);
		}
	}
}
