using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_MinimalElements : AssertionHelper
	{
		[Test]
		public void Empty_Div()
		{
			var d = "div".Add();

			Expect(d.ToString(), Is.EqualTo("<div/>"));
		}

		[Test]
		public void Adding_Numbers()
		{
			var h = "div".Add(1);

			var d = h.ToString();

			Expect(d, Is.EqualTo("<div>1</div>"));
		}

		[Test]
		public void Div_With_Text()
		{
			var d = "div".Add("text");

			Expect(d.ToString(), Is.EqualTo("<div>text</div>"));
		}

		[Test]
		public void Div_With_Nested_Element_And_Text()
		{
			var d = "div".Add("span".Add("text"));

			Expect(d.ToString(), Is.EqualTo("<div><span>text</span></div>"));
		}

		[Test]
		public void Div_With_Id()
		{
			var d =
				"div".Attr("id", "my-id").Add(
					"span".Add("text"));

			Expect(d.ToString(), Is.EqualTo(@"<div id=""my-id""><span>text</span></div>"));
		}

		[Test]
		public void Div_3_Levels()
		{
			var d =
				"div".Add(
					"span".Add("span".Add("span".Add())));

			Expect(d.ToString(), Is.EqualTo(
				@"<div><span><span><span/></span></span></div>"));
		}

		[Test]
		public void Div_Add_As_Node()
		{
			var d = "div".Add("span".Add());

			Expect(d.ToString(), Is.EqualTo(@"<div><span/></div>"));
		}

		[Test]
		public void AddIf_False_No_Else()
		{
			var d = "div".Add("span".Add().AddIf(false, () => "span".Add()));

			Expect(d.ToString(), Is.EqualTo(@"<div><span/></div>"));
		}

		[Test]
		public void AddIf_True_No_Else()
		{
			var d = "div".Add("span".Add().AddIf(true, () => "span".Add()));

			Expect(d.ToString(), Is.EqualTo(@"<div><span><span/></span></div>"));
		}

		[Test]
		public void AddIf_True_With_Else()
		{
			var d = "div".Add("span".Add().AddIf(true, () => "span".Add(), () => "em".Add()));

			Expect(d.ToString(), Is.EqualTo(@"<div><span><span/></span></div>"));
		}

		[Test]
		public void AddIf_False_With_Else()
		{
			var d = "div".Add("span".Add().AddIf(false, () => "span".Add(), () => "em".Add()));

			Expect(d.ToString(), Is.EqualTo(@"<div><span><em/></span></div>"));
		}

		[Test]
		public void AttrIf_True_No_Else()
		{
			var d =
				"div".Add(
					"span".AttrIf(true, () => new[] { "id", "my-id" }));

			Expect(d.ToString(), Is.EqualTo(@"<div><span id=""my-id""/></div>"));
		}
	}
}
