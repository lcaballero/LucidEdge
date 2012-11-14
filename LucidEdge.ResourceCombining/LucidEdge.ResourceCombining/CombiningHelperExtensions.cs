using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LucidEdge.ResourceCombining
{
	public static class CombiningHelperExtensions
	{
		public static StringBuilder CombineContents(
			this StringBuilder buff,
			IEnumerable<string> paths,
			ContentResolver cr)
		{
			return
			paths.Aggregate(
				buff,
				(acc, path) =>
				acc.Append(File.ReadAllText(cr.ResolveUrl(path))));
		}
	}
}
