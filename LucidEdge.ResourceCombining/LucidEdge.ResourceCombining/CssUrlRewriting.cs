using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LucidEdge.ResourceCombining
{
	public static class CssUrlRewriting
	{
		private static Regex _UrlExpression = new Regex(@"url(?<!\\)\(\s*(.*?)\s*(?<!\\)\)", RegexOptions.Multiline | RegexOptions.IgnoreCase);
		private static Regex _FilterExpression = new Regex(@"src='(.*?)'", RegexOptions.Multiline | RegexOptions.IgnoreCase);
		private static Regex _AbsoluteUrlExpression = new Regex(@".*?://.*?");

		private static Regex _ImportExpresion = new Regex(string.Concat(
			"@import", "\\s*",
			// Optional URL opening
				"(?:url\\()?",
			// String part
					"(\\s*(.*?)\\s*)",
			// Optional URL closing
				"(?:\\))?", "\\s*",
			// Ends with a ; or a {
			"(?:;|\\{)"
		));

		public static string RewriteCss(this string css, Func<string,string> rewritePath)
		{
			string content = _UrlExpression.Replace(
				css,
				new MatchEvaluator(
					(match) =>
					{
						var s = match.Groups[1].Value;

						return rewritePath(s);
					}));

			return content;
		}
	}
}
