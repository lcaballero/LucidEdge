using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_AddingHtmlRenderables : AssertionHelper
	{
		private class BasicRenderable : IHtmlRenderable
		{
			public IHtml ToHtml()
			{
				return "div.container".Add("h3".Add("Grab bar"));
			}
		}

		private class ContainerRenderable : IHtmlRenderable
		{
			public IHtml ToHtml()
			{
				return "div.container".Add();
			}
		}

		private class NavRenderable : IHtmlRenderable
		{
			public string Text { get; set; }

			public IHtml ToHtml()
			{
				return "li".Add(Text);
			}
		}

		[Test]
		public void Adding_SimpleRenderable()
		{
			var e = "body".Add(new BasicRenderable());

			Expect(e.ToString(), Is.EqualTo(
				@"<body><div class=""container""><h3>Grab bar</h3></div></body>"));
		}

		[Test]
		public void Adding_ContainerRenderable()
		{
			var e = "body".Add(
				new ContainerRenderable(),
				new ContainerRenderable(),
				new ContainerRenderable());

			Expect(e.ToString(), Is.EqualTo(
				@"<body><div class=""container""/><div class=""container""/><div class=""container""/></body>"));
		}

		[Test]
		public void Adding_NavRenderable()
		{
			var items = new List<string> { "Nav1", "Nav2", "Nav3" };
			var a = "ul".Add(items.Select(s => new NavRenderable { Text = s }));

			Expect(a.ToString(), Is.EqualTo(
				@"<ul><li>Nav1</li><li>Nav2</li><li>Nav3</li></ul>"));
		}

		[Test]
		public void Adding_Multiple_NavRenderables()
		{
			var items = new List<string> { "Nav1", "Nav2", "Nav3" };
			var a = "ul".Add(
				items.Select(s => new NavRenderable { Text = s }),
				items.Select(s => new NavRenderable { Text = s }),
				items.Select(s => new NavRenderable { Text = s }));

			Expect(a.ToString(), Is.EqualTo(
				"<ul>"
				+ @"<li>Nav1</li><li>Nav2</li><li>Nav3</li>"
				+ @"<li>Nav1</li><li>Nav2</li><li>Nav3</li>"
				+ @"<li>Nav1</li><li>Nav2</li><li>Nav3</li>"
				+ "</ul>"));
		}

		[Test]
		public void Adding_Multiple_Types_2()
		{
			var items = new List<string> { "Nav1", "Nav2", "Nav3" };
			var a = "ul".Add(
				items.Select(s => new NavRenderable { Text = s }),
				"Start Nav 2",
				items.Select(s => new NavRenderable { Text = s }),
				items.Select(s => new NavRenderable { Text = s }));

			Expect(a.ToString(), Is.EqualTo(
				"<ul>"
				+ @"<li>Nav1</li><li>Nav2</li><li>Nav3</li>"
				+ @"Start Nav 2"
				+ @"<li>Nav1</li><li>Nav2</li><li>Nav3</li>"
				+ @"<li>Nav1</li><li>Nav2</li><li>Nav3</li>"
				+ "</ul>"));
		}

		[Test]
		public void Adding_Multiple_Types_3()
		{
			var items = new List<string> { "Nav1", "Nav2", "Nav3" };
			var a =
				"div".Add(
					"ul".Add(
						items.Select(s => new NavRenderable { Text = s }),
						"Start Nav 2",
						items.Select(s => new NavRenderable { Text = s }),
						"span".Add("Start Nav 3"),
						items.Select(s => new NavRenderable { Text = s }),
						"Nav over"))
					.Add("div".Add("After div"));

			Expect(a.ToString(), Is.EqualTo(
				"<div>"
				+ "<ul>"
				+ "<li>Nav1</li><li>Nav2</li><li>Nav3</li>"
				+ "Start Nav 2"
				+ "<li>Nav1</li><li>Nav2</li><li>Nav3</li>"
				+ "<span>Start Nav 3</span>"
				+ "<li>Nav1</li><li>Nav2</li><li>Nav3</li>"
				+ "Nav over"
				+ "</ul>"
				+ "<div>After div</div>"
				+ "</div>"));
		}
	}
}
