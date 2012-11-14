using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using LucidEdge.StringBuilding.DifferenceEngine;

namespace LucidEdge.StringBuilding.Tests.DifferenceEngine
{
	[TestFixture]
	public class Test_ToHtml : AssertionHelper
	{
		[Test]
		public void Differences()
		{
			var before = File.ReadAllText("Files/Diff-1-Before.txt");
			var after = File.ReadAllText("Files/Diff-1-After.txt");

			var dmp = new DiffMatchPatch();
			var diffs = dmp.diff_main(before, after);
			var html = dmp.diff_prettyHtml(diffs);

			Console.WriteLine("\n Before: \n");
			Console.WriteLine(before);

			Console.WriteLine("\n Merged: \n");
			Console.WriteLine(html);
		}
	}
}
