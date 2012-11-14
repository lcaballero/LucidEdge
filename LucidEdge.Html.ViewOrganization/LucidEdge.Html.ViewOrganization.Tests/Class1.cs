using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using LucidEdge.Html.ViewOrganization.HtmlDocument;
using LucidEdge.Html.ViewOrganization.Rendering.LinkTags;
using LucidEdge.Html.ViewOrganization.Rendering.ScriptTags;
using LucidEdge.Html.ViewOrganization.Rendering;


namespace LucidEdge.Html.ViewOrganizationTests
{
	public class Content : HtmlContainer
	{
		public override IHtml ToHtml()
		{
			return 
			"div".Add(
				"h1".Add("testing the addition of content"),
				"div".Add("followed by scripts"));
		}
	}

	public class FileSystemDocument : DefaultDocument
	{
		public List<string> Resources =
			new List<string>
			{
				"~/Content/Scripts/PageManager/Doc_PageManager.css",
				"~/Content/Scripts/PageManager/Doc_PageManager.css",
				"~/Content/Scripts/PageManager/Doc_PageManager.css",
				"~/Content/Scripts/PageManager/Doc_PageManager.css",
				"~/Content/Scripts/PageManager/Doc_PageManager.css"
			};

		public override IHtml ToHtml()
		{
			return
			Html.Add(
				Head.Add(Resources.ToLinkTags()),
				Body.Add(
					Content,
					"script".Attr(
						"type", "text/javascript",
						"src", "../Content/Scripts/PageManagers/Documentation_PageManager.js".ResolveUrl())));
		}
	}

	public class FileSystemPathResolver : IPathResolver
	{
		public string ResolveUrl(string href)
		{
			if (href.StartsWith("~/"))
			{
				return "../../../../" + href.Substring(2).ToString();
			}

			return href;
		}
	}

	[TestFixture]
	public class Class1 : AssertionHelper
	{
		[Test]
		public void Gaurantee_Only_One_Html_Closing_Tag()
		{
			UrlResolver.HrefResolver =
				new Lazy<IPathResolver>(() => new FileSystemPathResolver());

			var fs = new FileSystemDocument { Content = new Content() };

			var html = fs.ToHtml().ToString();

			Expect(!string.IsNullOrEmpty(html));

			int n1 = html.IndexOf("</html>");

			Expect(n1, Is.GreaterThanOrEqualTo(0));

			int n2 = html.IndexOf("</html>", n1+1);

			Expect(n2, Is.LessThan(0));
		}
	}
}
