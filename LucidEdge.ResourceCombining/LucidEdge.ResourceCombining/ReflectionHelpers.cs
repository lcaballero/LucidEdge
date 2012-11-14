using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LucidEdge.Html.ViewOrganization.Controllers.ActionFilters;
using LucidEdge.Html.ViewOrganization.Rendering;
using System.Reflection;


namespace LucidEdge.ResourceCombining
{
	public static class ReflectionHelpers
	{
		public static CombinedResources ToCombinedResources(
			this IEnumerable<IEnumerable<PathedActions>> allCaches,
			ContentResolver cr)
		{
			return
			new CombinedResources
			{
				Caches = allCaches
					.CombineFiles(cr)
					.SelectMany(c => c).ToList()
			};
		}

		public static IEnumerable<IEnumerable<Cache>> CombineFiles(
			this IEnumerable<IEnumerable<PathedActions>> actionsPerAssembly,
			ContentResolver cr)
		{
			return
			actionsPerAssembly
				.Select(
					p => 
					p.Select(
						pa =>
						new Cache
						{
							ActionName = pa.Method.Name,
							ControllerName = pa.Controller.Name,
							ActionPath = pa.ActionPath,
							Paths = pa.PathedAttribute.Paths,
							RawSource = new StringBuilder().CombineContents(pa.Paths, cr).ToString()
						}));
		}

		public static IEnumerable<PathedActions> FindAttributes<T>(
			this IEnumerable<Type> controllers)
				where T : ResourceCollectionAttribute
		{
			return
			controllers
				.SelectMany(
					c =>
					c.GetMethods()
						.Select(
							m =>
							new PathedActions
							{
								Controller = c,
								PathedType = typeof(T),
								Method = m,
								PathedAttribute = m
									.GetCustomAttributes(typeof(T), false)
									.Cast<T>()
									.FirstOrDefault()
							}))
				.Where(p => p.PathedAttribute != null);
		}

		public static IEnumerable<IEnumerable<PathedActions>> FindAttributes<T>(
			this IEnumerable<IEnumerable<Type>> controllersPerAssembly)
				where T : ResourceCollectionAttribute
		{
			return
			controllersPerAssembly
				.Select(a => a.FindAttributes<T>());
		}

		public static IEnumerable<IEnumerable<Type>> FindControllers(
			this Assembly assembly)
		{
			return typeof(System.Web.Mvc.Controller).FindTypes(assembly);
		}

		public static IEnumerable<IEnumerable<Type>> FindTypes(
			this Type target, params Assembly[] assemblies)
		{
			return
			assemblies.Select(
				assembly =>
				assembly
					.GetTypes()
					.Where(t => t.IsDerivedFrom(target)));
		}

		public static bool IsDerivedFrom(this Type c, Type parent)
		{
			var d = c.FullName == parent.FullName;
			var b =
				c == null ? false :
				!c.IsClass ? false :
				c == typeof(Object) ? false :
				c.FullName == parent.FullName ? true :
				c.BaseType.IsDerivedFrom(parent);

			return b;
		}
	}
}
