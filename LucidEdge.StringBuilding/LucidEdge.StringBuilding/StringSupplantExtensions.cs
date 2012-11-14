using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;


namespace LucidEdge.StringBuilding
{
	public static class StringSupplantExtensions
	{
		public static readonly Regex RE =
			new Regex("({.*?})", RegexOptions.Multiline);

		public static string Supplant(
			this string fmt,
			Dictionary<string, object> dps)
		{
			return RE.Replace(fmt, (m) => m.Map(dps));
		}

		public static string Supplant(this string fmt, object dps)
		{
			var lookup = 
				dps is Dictionary<string, object>
					? (Dictionary<string, object>)dps
					: dps.ToProperties();

			return RE.Replace(fmt, (m) => m.Map(lookup));
		}

		public static Dictionary<string, object> ToProperties(this object ab)
		{
			Type type = ab.GetType();

			return
			type.GetProperties()
				.Aggregate(
					new Dictionary<string, object>(),
					(acc, prop) =>
					{
						acc[prop.Name] = Invoke(ab, type, prop.Name);
						return acc;
					});
		}

		public static object Invoke(this object ab, Type type, string name)
		{
			return type.GetProperty(name).GetValue(ab, null);
		}

		public static string Map(
			this Match m,
			Dictionary<string, object> dps)
		{
			return dps.ContainsKey(m.Value.RemoveBraces())
				? (dps[m.Value.RemoveBraces()] ?? "").ToString()
				: "";
		}

		public static string RemoveBraces(this string s)
		{
			return
			s.StartsWith("{") && s.EndsWith("}") ? s.Substring(1, s.Length - 2) : s;
		}
	}
}
