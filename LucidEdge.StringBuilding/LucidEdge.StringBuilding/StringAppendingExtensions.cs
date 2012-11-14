using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LucidEdge.StringBuilding.Helpers;


namespace LucidEdge.StringBuilding
{
	public static class StringAppendingExtensions
	{
		public static StringBuilder AppendBetween(
			this StringBuilder buf, int n, int count, string sep = ",", string end = "")
		{
			return buf.AppendIf(n < count - 1, () => sep, () => end);
		}

		public static StringBuilder AppendLines(
			this StringBuilder buf, IEnumerable<string> items)
		{
			return
			items.Aggregate(
				buf,
				(acc, s) => acc.AppendLine(s));
		}

		public static StringBuilder AppendAll(
			this StringBuilder buffer, IEnumerable<string> items)
		{
			return
			buffer.AppendAll(
				items,
				(buf, item) => buf.Append(item == null ? "" : item));
		}

		public static StringBuilder AppendAll<T>(
			this StringBuilder buf,
			IEnumerable<T> items,
			Func<StringBuilder, T, StringBuilder> fn)
		{
			return items.Aggregate(buf, fn);
		}

		public static StringBuilder AppendAll<T>(
			this StringBuilder buf,
			bool condition,
			Func<IEnumerable<T>> items,
			Func<StringBuilder, T, int, StringBuilder> fn)
		{
			return condition ? items().Aggregate(buf, fn) : buf;
		}

		public static StringBuilder AppendIf(
			this StringBuilder buf,
			string val)
		{
			return
				string.IsNullOrEmpty(val)
					? buf
					: buf.Append(val);
		}

		public static StringBuilder AppendAll<T>(
			this StringBuilder buf,
			bool condition,
			Func<IEnumerable<T>> items,
			Func<StringBuilder, T, StringBuilder> fn)
		{
			return condition ? items().Aggregate(buf, fn) : buf;
		}

		public static StringBuilder AppendIf(
			this StringBuilder buf,
			bool condition,
			Func<string> truefn = null,
			Func<string> falsefn = null)
		{
			return
				condition && truefn != null ? buf.Append(truefn()) :
				!condition && falsefn != null ? buf.Append(falsefn()) :
				buf;
		}

		public static StringBuilder AppendIf(
			this StringBuilder buf,
			bool condition,
			Func<IEnumerable<string>> truefn = null,
			Func<IEnumerable<string>> falsefn = null)
		{
			return
				condition && truefn != null ? buf.AppendAll(truefn()) :
				!condition && falsefn != null ? buf.AppendAll(falsefn()) :
				buf;
		}

		public static StringBuilder AppendIf(
			this StringBuilder buf,
			bool condition,
			string val,
			params string[] args)
		{
			if (condition)
			{
				buf.AppendFormat(val, args);
			}
			return buf;
		}
	}
}
