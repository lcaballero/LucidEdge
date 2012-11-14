using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_ParseClasses : AssertionHelper
	{
		[Test]
		public void ParseClasses_Null()
		{
			var classes = ((string)null).ParseClasses();

			Expect(classes, Is.EqualTo(""));
		}

		[Test]
		public void ParseClasses_Empty()
		{
			var classes = "".ParseClasses();

			Expect(classes, Is.EqualTo(""));
		}

		[Test]
		public void ParseClasses_NoTag_Class()
		{
			var classes = ".my-class".ParseClasses();

			Expect(classes, Is.EqualTo("my-class"));
		}

		[Test]
		public void ParseClasses_Div()
		{
			var classes = "div".ParseClasses();

			Expect(classes, Is.EqualTo(""));
		}

		[Test]
		public void ParseClasses_Div_Id()
		{
			var classes = "div#id".ParseClasses();

			Expect(classes, Is.EqualTo(""));
		}

		[Test]
		public void ParseClasses_Div_Class()
		{
			var classes = "div.my-class".ParseClasses();

			Expect(classes, Is.EqualTo("my-class"));
		}

		[Test]
		public void ParseClasses_Div_Id_Class()
		{
			var classes = "div#my-id.my-class".ParseClasses();

			Expect(classes, Is.EqualTo("my-class"));
		}

		[Test]
		public void ParseClasses_Div_Class_Id()
		{
			var classes = "div.my-class-1#my-id".ParseClasses();

			Expect(classes, Is.EqualTo("my-class-1"));
		}

		[Test]
		public void ParseClasses_Div_Class_Id_Class()
		{
			var classes = "div.my-class-1#my-id.my-class-2".ParseClasses();

			Expect(classes, Is.EqualTo("my-class-1 my-class-2"));
		}

		[Test]
		public void ParseClasses_Div_Class_Class()
		{
			var classes = "div.my-class-1.my-class-2".ParseClasses();

			Expect(classes, Is.EqualTo("my-class-1 my-class-2"));
		}
	}
}
