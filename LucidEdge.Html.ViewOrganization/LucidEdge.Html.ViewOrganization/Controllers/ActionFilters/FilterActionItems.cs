using System.Collections.Generic;
using System.Web;
using System;
using LucidEdge.Html.ViewOrganization.Rendering;


namespace LucidEdge.Html.ViewOrganization.Controllers.ActionFilters
{
	public static class FilterActionItems
	{
		public static List<Type> InlineModules
		{
			get { return "InlineModules".Get<List<Type>>(); }
			set { "InlineModules".Set<List<Type>>(value); }
		}

		public static List<string> Styles
		{
			get { return "Styles".Get<List<string>>(); }
			set { "Styles".Set<List<string>>(value); }
		}

		public static List<string> Scripts
		{
			get { return "Scripts".Get<List<string>>(); }
			set { "Scripts".Set<List<string>>(value); }
		}

		public static List<string> Inlines
		{
			get { return "Inlines".Get<List<string>>(); }
			set { "Inlines".Set<List<string>>(value); }
		}

		public static List<string> JavaScriptPackages
		{
			get { return "JavaScriptPackages".Get<List<string>>(); }
			set { "JavaScriptPackages".Set<List<string>>(value); }
		}

		public static List<string> StylesheetPackages
		{
			get { return "StylesheetPackages".Get<List<string>>(); }
			set { "StylesheetPackages".Set<List<string>>(value); }
		}

		public static AppHomePathResolver HomeResolver
		{
			get { return "AppHomePathResolver".Get<AppHomePathResolver>(); }
			set { "AppHomePathResolver".Set<AppHomePathResolver>(value); }
		}

		public static T Get<T>(this string s)
			where T : new()
		{
			if (!HttpContext.Current.Items.Contains(s))
			{
				HttpContext.Current.Items[s] = new T();
			}

			return (T)HttpContext.Current.Items[s];
		}

		public static T Set<T>(this string s, T item)
			where T : new()
		{
			if (!HttpContext.Current.Items.Contains(s))
			{
				HttpContext.Current.Items[s] = item;
			}

			return (T)HttpContext.Current.Items[s];
		}

	}
}