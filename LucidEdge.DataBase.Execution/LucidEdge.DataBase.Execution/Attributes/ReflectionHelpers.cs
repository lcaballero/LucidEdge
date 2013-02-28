using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;


namespace LucidEdge.DataBase.Execution
{
	public static class ReflectionHelpers
	{
		public static IEnumerable<T> FindAttribute<T>(this PropertyInfo p)
		{
			return p.GetCustomAttributes(typeof(T), true).Cast<T>();
		}

		public static List<T> FillDomainObjects<T>(
			this List<List<OutputPoint>> data)
				where T : new()
		{
			return
			data.Select(points => new T().FillDomainObject(points))
				.ToList();
		}

		public static T FillDomainObject<T>(this T target, List<OutputPoint> r)
		{
			return
			target.FillDomainObject(
				r.ToDictionary(
					p => p.ColumnName,
					p => p.Value, StringComparer.CurrentCultureIgnoreCase));
		}

		public static T FillDomainObject<T>(
			this T target, Dictionary<string,object> values)
		{
			target.GetType()
				.GetProperties()
				.Select(prop => new ColumnMapping(prop, target))
				.Where(cm => !cm.IsMarkedIgnored && values.ContainsKey(cm.ToColumnName()))
				.ToList()
				.ForEach(
					col =>
					col.PropertyInfo.SetValue(
						target, values[col.ToColumnName()], null));

			return target;
		}

		public static List<OutputPoint> ToOutputPoints(this Dictionary<string, object> map)
		{
			return
			map.Select(
				kvp =>
				new OutputPoint
				{
					ColumnName = kvp.Key,
					Value = kvp.Value,
					DbType = 
						kvp.Value == null
							? DbType.Object
							: kvp.Value.GetType().ToDbType()
				})
				.ToList();
		}

		public static List<OutputPoint> ToOutputPoints<T>(this T source)
			where T : class
		{
			return
			source.GetType()
				.GetProperties()
				.Select(p => new ColumnMapping(p, source))
				.Where(cm => !cm.IsMarkedIgnored)
				.Select(
					p =>
					new OutputPoint
					{
						ColumnName = p.ToColumnName(),
						Value = p.PropertyInfo.GetValue(p.Source, null),
						DbType = p.ToDbType()
					})
				.ToList();
		}

		public static string ToColumnName(this ColumnMapping p)
		{
			return
			p.ColumnMap == null || string.IsNullOrEmpty(p.ColumnMap.ColumnName)
				? p.PropertyInfo.Name
				: p.ColumnMap.ColumnName;
		}

		public static DbType ToDbType(this ColumnMapping m)
		{
			return
			m.PropertyInfo.PropertyType == typeof(string)
				? DbType.String
				: m.PropertyInfo.PropertyType.ToDbType();
		}

		public static DbType ToDbType(this Type t)
		{
			return
			t == typeof(string)
				? DbType.String
				:
			t == typeof(int) || t == typeof(int?)
				? DbType.Int32
				:
			t == typeof(long) || t == typeof(long?)
				? DbType.Int64
				:
			t == typeof(double) || t == typeof(float)
			|| t == typeof(double?) || t == typeof(float?)
				? DbType.Double
				:
			t == typeof(bool) || t == typeof(bool?)
				? DbType.Boolean
				:
			t == typeof(DateTime) || t == typeof(DateTime?)
				? DbType.DateTime
				:
			t == typeof(DateTimeOffset) || t == typeof(DateTimeOffset?)
				? DbType.DateTimeOffset
				:
			DbType.Object;
		}
	}
}
