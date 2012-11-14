using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LucidEdge.Html
{
	public class Html : IHtml
	{
		public string Name { get; set; }
		public object Value { get; set; }
		public IList<IHtml> Children { get; set; }
		public IDictionary<string,string> Attributes { get; set; }

		public Html() {}

		public IHtml ToHtml() { return this; }

		public bool HasChildren { get { return Children != null && Children.Count > 0; } }
		public bool HasAttributes { get { return Attributes != null; } }
		public bool IsElement { get { return !string.IsNullOrEmpty(Name); } }

		public bool IsFragment
		{
			get
			{
				return 
				string.IsNullOrEmpty(Name)
				&& Value == null
				&& Attributes == null;
			}
		}

		public bool IsText
		{
			get
			{
				return
				string.IsNullOrEmpty(Name)
				&& Children == null
				&& Attributes == null
				&& Value != null;
			}
		}

		public override string ToString()
		{
			return Write(new StringWriter()).ToString();
		}

		public TextWriter Write(TextWriter tw)
		{
			if (IsText)
			{
				tw.Write(Value);
			}
			else if (IsFragment)
			{
				Children
					.ToList()
					.ForEach(part => part.Write(tw, false, 0, "   ", ""));
			}
			else if (IsElement)
			{
				this.Write(tw, false, 0, "   ", "");
			}

			return tw;
		}

		public TextWriter Write(TextWriter tw, bool indent, int level, string tab, string indentation)
		{
			//Indent(tw, indent, level, indenting);

			tw.Write("<");
			tw.Write(Name);

			if (HasAttributes)
			{
				Attributes
					.ToList()
					.ForEach(
						part => tw.Write(string.Format(" {0}=\"{1}\"", part.Key, part.Value)));
			}

			List<IHtml> children = HasChildren ? Children.ToList() : null;

			if (children != null && children.Count > 0)
			{
				tw.Write(">");

				//Indent(tw, indent, level, indenting + tab);

				foreach (var item in children)
				{
					if (item == null)
					{
						continue;
					}

					if (item.IsElement || item.IsFragment)
					{
						item.Write(tw, indent, ++level, tab, indentation + tab);
					}
					else
					{
						item.Write(tw);
					}
				}

				//Indent(tw, indent, level, indenting);

				tw.Write("</");
				tw.Write(Name);
				tw.Write(">");

				//Indent(tw, indent, level, "");
			}

			if (children == null || children.Count <= 0)
			{
				tw.Write("/>");
			}

			return tw;
		}

		private static void Indent(TextWriter tw, bool indent, int level, string indenting)
		{
			if (indent)
			{
				if (level > 0)
				{
					tw.Write("\n");
				}

				tw.Write(indenting);
			}
		}
	}
}
