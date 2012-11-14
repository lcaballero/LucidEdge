using LucidEdge.Html.ViewOrganization.Rendering;


namespace LucidEdge.ResourceCombining
{
	public class ContentResolver : IPathResolver
	{
		public string ContentDir { get; set; }

		public string ResolveUrl(string href)
		{
			var url =
				href.StartsWith("~/")
				? ContentDir.NormalizePath() + href.Substring(2)
				: href;

			return url.Replace('/', '\\');
		}
	}
}
