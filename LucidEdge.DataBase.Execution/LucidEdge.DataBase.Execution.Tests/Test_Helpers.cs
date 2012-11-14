using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace LucidEdge.DataBase.Execution.Tests
{
	[TestFixture]
	public class Test_Helpers : AssertionHelper
	{
		[Test]
		public void Read_Content()
		{
			var content = "SqlScripts/Mod-Overflow/Create-Tables.sql".Read();

			Expect(content, Is.Not.Null);
			Expect(content.Length, Is.GreaterThan(0));
		}
	}
}
