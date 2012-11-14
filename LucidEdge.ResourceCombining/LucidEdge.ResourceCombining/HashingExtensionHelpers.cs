using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.IO;
using LucidEdge.Html.ViewOrganization.Rendering;


namespace LucidEdge.ResourceCombining
{
	public static class HashingExtensionHelpers
	{
		public static string GetMD5Hash(this byte[] bytes)
		{
			MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
			byte[] bs = x.ComputeHash(bytes);
			var s = new StringBuilder();

			foreach (byte b in bs)
			{
				s.Append(b.ToString("x2").ToLower());
			}

			return s.ToString();
		}

		public static string GetMD5Hash(this string input)
		{
			MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
			byte[] bs = x.ComputeHash(Encoding.UTF8.GetBytes(input));
			var s = new StringBuilder();

			foreach (byte b in bs)
			{
				s.Append(b.ToString("x2").ToLower());
			}

			return s.ToString();
		}

		public static string NamesAndTimes(this List<string> paths)
		{
			return
			paths
				.Select(p => p.ResolveUrl())
				.Aggregate(
					new StringBuilder(),
					(acc, path) =>
					acc.AppendLine(path)
						.AppendLine(
							File.GetLastWriteTime(path)
								.ToLongDateString()))
				.ToString()
				.GetMD5Hash();
		}
	}
}
