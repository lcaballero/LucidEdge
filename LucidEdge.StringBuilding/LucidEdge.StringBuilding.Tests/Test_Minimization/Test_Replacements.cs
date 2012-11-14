using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LucidEdge.StringBuilding.Succinct;
using System.IO;

namespace LucidEdge.StringBuilding.Tests.Minimization_Tests
{
	[TestFixture]
	public class Test_Replacements : AssertionHelper
	{
		[Test]
		public void Fill_Rules()
		{
			var rules = Substitutions.Rules.ToRules();

			Expect(rules.Count > 0);
		}

		[Test]
		public void Apply_Rules_To_Sentences()
		{
			var rules = Substitutions.Rules.ToRules();
			var sentences = 
				new List<Sentence>
				{
					new Sentence(File.ReadAllText("Files/Sentence-1.txt"))
				}
				.Process(rules);

			Expect(sentences, Is.Not.Null);

			Expect(
				sentences[0].Original,
				Is.EqualTo("We realized because it had eight legs it must be a spider."));

			Expect(
				sentences[0].Text,
				Is.EqualTo("we realized because it had eight legs it must be a spider."));
		}

		[Test]
		public void Apply_Rules_To_Single_Sentence()
		{
			var rules = Substitutions.Rules.ToRules();
			var sentence =
				new Sentence(File.ReadAllText("Files/Sentence-1.txt"))
					.Process(rules);

			Expect(sentence, Is.Not.Null);

			Expect(
				sentence.Original,
				Is.EqualTo("We realized because it had eight legs it must be a spider."));

			Expect(
				sentence.Text,
				Is.EqualTo("we realized because it had eight legs it must be a spider."));
		}
	}
}
