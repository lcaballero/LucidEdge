using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LucidEdge.Html.Tests
{
	[TestFixture]
	public class Test_ParseId : AssertionHelper
	{
		[Test]
		public void ParseId_Null()
		{
			var id = ((string)null).ParseId();

			Expect(id, Is.EqualTo(""));
		}

		[Test]
		public void ParseId_Empty()
		{
			var id = "".ParseId();

			Expect(id, Is.EqualTo(""));
		}

		[Test]
		public void ParseId_NoTag()
		{
			var id = "#my-id".ParseId();

			Expect(id, Is.EqualTo("my-id"));
		}

		[Test]
		public void ParseId_NoId_NoClasses()
		{
			var id = "div".ParseId();

			Expect(id, Is.EqualTo(""));
		}

		[Test]
		public void ParseId_Id_NoClasses()
		{
			var id = "div#my-id".ParseId();

			Expect(id, Is.EqualTo("my-id"));
		}

		[Test]
		public void ParseId_NoId_Class()
		{
			var id = "div.my-classes".ParseId();

			Expect(id, Is.EqualTo(""));
		}

		[Test]
		public void ParseId_Id_Class()
		{
			var id = "div#my-id.my-classes".ParseId();

			Expect(id, Is.EqualTo("my-id"));
		}

		[Test]
		public void ParseId_Class_Id_Class()
		{
			var id = "div.my-classes-1#my-id.my-class-2".ParseId();

			Expect(id, Is.EqualTo("my-id"));
		}

		[Test]
		public void ParseId_Class_Id_Class_Class()
		{
			var id = "div.my-classes-1#my-id.my-class-2.my-class-3".ParseId();

			Expect(id, Is.EqualTo("my-id"));
		}

		[Test]
		public void ParseId_Spaces_Class_Id_Class_Class()
		{
			var id = "div.my-classes-1#my-id.my-class-2 my-class-3".ParseId();

			Expect(id, Is.EqualTo("my-id"));
		}
	}
}
