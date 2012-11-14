using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace LucidEdge.ResourceCombining
{
	[XmlRoot("combined-resources")]
	public class CombinedResources
	{
		[XmlArray("caches")]
		[XmlArrayItem("cache")]
		public List<Cache> Caches { get; set; }

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return
			obj is CombinedResources
				&& new HashSet<Cache>(Caches).IsSubsetOf(
					new HashSet<Cache>(((CombinedResources)obj).Caches));
		}
	}

	public class Source
	{
		[XmlIgnore]
		public string Code { get; set; }

		[XmlText]
		public XmlNode[] CombinedSource
		{
			get
			{
				var dummy = new XmlDocument();
				return new XmlNode[] { dummy.CreateCDataSection(Code) };
			}
			set
			{
				if (value == null)
				{
					Code = null;
					return;
				}

				if (value.Length != 1)
				{
					throw new InvalidOperationException(
						string.Format(
							"Invalid array length {0}", value.Length));
				}

				Code = value[0].Value;
			}
		}

		public static implicit operator Source(string cdata)
		{
			var dummy = new XmlDocument();
			var nodes = new XmlNode[] { dummy.CreateCDataSection(cdata) };

			return
			new Source
			{
				CombinedSource = nodes
			};
		}
	}

	public class Cache
	{
		[XmlArray("assets")]
		[XmlArrayItem("asset-path")]
		public List<string> Paths { get; set; }

		[XmlElement("action-path")]
		public string ActionPath { get; set; }

		[XmlElement("controller-name")]
		public string ControllerName { get; set; }

		[XmlElement("action-name")]
		public string ActionName { get; set; }

		[XmlElement("hash")]
		public string Hash { get; set; }

		[XmlElement("raw-source")]
		public Source RawSource { get; set; }

		public override int GetHashCode()
		{
			return 
			string.Format(
				"{0}, {1}, {2}, {3}, {4}, {5}",
				string.Join(",", Paths.ToArray()),
				ActionPath,
				ControllerName,
				ActionName,
				Hash,
				RawSource.Code).GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Cache))
			{
				return false;
			}

			var rhs = (obj as Cache);

			return
			Paths.Count == rhs.Paths.Count
			&& Paths.SequenceEqual(rhs.Paths)
			&& ActionPath == rhs.ActionPath
			&& Hash == rhs.Hash
			&& ControllerName == rhs.ControllerName
			&& ActionName == rhs.ActionName
			&& RawSource.Code == rhs.RawSource.Code;
		}
	}
}
