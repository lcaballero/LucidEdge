using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LucidEdge.Html.ViewOrganization.Rendering
{
	public static class UrlResolver
	{
		public static IPathResolver Resolver
		{
			get { return HrefResolver.Value; }
		}

		public static Lazy<IPathResolver> HrefResolver
		{
			get
			{
				return
				_HrefResolver =
				_HrefResolver == null
					? new Lazy<IPathResolver>(() => new DefaultPathResolver())
					: _HrefResolver;
			}
			set { _HrefResolver = value; }
		}
		private static Lazy<IPathResolver> _HrefResolver = null;

		public static string ResolveUrl(this string url)
		{
			return Resolver.ResolveUrl(url);
		}
	}
}