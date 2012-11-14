using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace LucidEdge.ResourceCombining.Tests
{
	[TestFixture]
	public class Test_Combining_Files : AssertionHelper
	{
		private static string FileSets()
		{
			var root = Path.Combine(Environment.CurrentDirectory, "../../Combining_Files_Sets/");
			root = Path.GetFullPath(root);

			return root;
		}

		[Test]
		public void Test_Empty_File_List()
		{
			var cr = new ContentResolver { ContentDir = FileSets() };

			Expect(!File.Exists(cr.ResolveUrl("~/Multiple_File_Set/Single-File-4.js")));
			Expect(!File.Exists(cr.ResolveUrl("~/Multiple_File_Set/Single-File-5.js")));
			Expect(!File.Exists(cr.ResolveUrl("~/Multiple_File_Set/Single-File-6.js")));
			Expect(!File.Exists(cr.ResolveUrl("~/Multiple_File_Set/Single-File-7.js")));
		}

		[Test]
		public void Test_Single_File_List()
		{
			var cr = new ContentResolver { ContentDir = FileSets() };

			Expect(File.Exists(cr.ResolveUrl("~/Multiple_File_Set/Single-File-0.js")));
			Expect(File.Exists(cr.ResolveUrl("~/Multiple_File_Set/Single-File-1.js")));
			Expect(File.Exists(cr.ResolveUrl("~/Multiple_File_Set/Single-File-2.js")));
			Expect(File.Exists(cr.ResolveUrl("~/Multiple_File_Set/Single-File-3.js")));
		}

		[Test]
		public void Combining_Multiple_Files()
		{
			var cr = new ContentResolver { ContentDir = FileSets() };

			var paths = new List<string>
			{
				"~/Multiple_File_Set/Single-File-0.js",
				"~/Multiple_File_Set/Single-File-1.js",
				"~/Multiple_File_Set/Single-File-2.js",
				"~/Multiple_File_Set/Single-File-3.js"
			};

			var buff = new StringBuilder().CombineContents(paths, cr).ToString();

			var names = paths.Select(p => Path.GetFileName(p));

			Expect(names.All(name => buff.Contains(name)));
		}
	}
}
