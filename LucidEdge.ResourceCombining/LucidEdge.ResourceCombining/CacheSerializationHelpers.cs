using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace LucidEdge.ResourceCombining
{
	public static class CacheSerializationHelpers
	{
		public static string Serialize<T>(this T t)
		{
			var xs = new XmlSerializer(typeof(T));
			var sw = new StringWriter();
			xs.Serialize(sw, t);
			var xml = sw.ToString();
			return xml;
		}

		public static T Deserialize<T>(this string xml)
		{
			var xs = new XmlSerializer(typeof(T));
			var sr = new StringReader(xml);
			var obj = xs.Deserialize(sr);

			return (T)obj;
		}
	}
}
