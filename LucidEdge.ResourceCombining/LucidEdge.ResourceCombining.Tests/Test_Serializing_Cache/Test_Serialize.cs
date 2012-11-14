using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.ResourceCombining.Tests
{
	[TestFixture]
	public class Test_Serialize : AssertionHelper
	{
		private CombinedResources SampleCache()
		{
			return
			new CombinedResources
			{
				Caches =
					new List<Cache>
					{
						new Cache
						{
							Hash = "Hash",
							RawSource = "PackageSource",
							ActionPath = "~/Controller/Action/",
							Paths =
								new List<string>
								{
									"~/Content/Scripts/file-1.js",
									"~/Content/Scripts/file-2.js",
									"~/Content/Scripts/file-3.js",
									"~/Content/Scripts/file-4.js",
								}
						}
					}
			};
		}

		[Test]
		public void Serialize_Cache()
		{
			var xml = SampleCache().Serialize();

			Console.WriteLine();
			Console.WriteLine(xml);

			Assert.Pass();
		}

		[Test]
		public void Deserialize_Cache()
		{
			var sc = SampleCache();
			var xml = sc.Serialize();
			var new_sc = xml.Deserialize<CombinedResources>();

			Assert.Pass();
		}

		[Test]
		public void Reference_Compare_Deserialize_Cache()
		{
			var sc = SampleCache();
			var xml = sc.Serialize();
			var new_sc = xml.Deserialize<CombinedResources>();

			Expect(sc.Equals(new_sc));
		}
	}
}
