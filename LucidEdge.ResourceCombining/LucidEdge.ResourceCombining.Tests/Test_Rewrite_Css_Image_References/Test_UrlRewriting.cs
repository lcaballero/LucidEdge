using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace LucidEdge.ResourceCombining.Tests
{
	[TestFixture]
	public class Test_UrlRewriting : AssertionHelper
	{
		public string _Hollywood_Css = null;
		public string Hollywood_Css
		{
			get
			{
				return
				_Hollywood_Css = _Hollywood_Css ??
				File.ReadAllText(
					Environment.CurrentDirectory
					+ "/../../Sample_Css_Urls/hollywood.com.css");
			}
		}

		[Test]
		public void Rewrite_Css_Urls()
		{
			List<string> urls = new List<string>();
			CssUrlRewriting.RewriteCss(Hollywood_Css, (s) => { urls.Add(s); return s; });

			urls.Output();

			Expect(urls.Count, Is.GreaterThan(2));
		}

		[Test]
		public void Find_Absolute_Urls()
		{
			List<string> urls = new List<string>();
			CssUrlRewriting.RewriteCss(Hollywood_Css, (s) => { urls.Add(s); return s; });

			urls = urls.Where(s => s.IsAbsoluteUrl()).Output();

			Expect(urls.Count, Is.EqualTo(7));
		}
	}
}