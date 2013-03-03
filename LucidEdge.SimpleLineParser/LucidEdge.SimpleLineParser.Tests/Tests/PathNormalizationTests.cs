using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace SimpleLineParser.Tests
{
	[TestFixture]
	public class PathNormalizationTests : AssertionHelper
	{
		[Test]
		public void Normalize_Empty_String()
		{
			var s = "".NormalizePathSeparators();

			Expect(s, Is.EqualTo(""));
		}

		[Test]
		public void Normalize_Root_Path()
		{
			var s = "/".NormalizePathSeparators();

			Expect(s, Is.EqualTo("\\"));
		}

		[Test]
		public void Normalize_Directory_And_File()
		{
			var s = "Some/Dir/With/File.txt".NormalizePathSeparators();

			Expect(s, Is.EqualTo("Some\\Dir\\With\\File.txt"));
		}

		[Test]
		public void Normalize_Rooted_Directory_And_File()
		{
			var s = "/Some/Dir/With/File.txt".NormalizePathSeparators();

			Expect(s, Is.EqualTo("\\Some\\Dir\\With\\File.txt"));
		}

		[Test]
		public void Normalize_MS_Rooted_Directory_And_File()
		{
			var s = "C:\\Some\\Dir\\With\\File.txt".NormalizePathSeparators();

			Expect(s, Is.EqualTo("C:\\Some\\Dir\\With\\File.txt"));
		}
	}
}

