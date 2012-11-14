using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LucidEdge.Html
{
	/// <summary>
	/// An IHtml is a struct that is a Facade of the various parts
	/// found in an Html Document.  For instance, an IHtml can be
	/// one of the following:
	/// 
	/// An Html Text Node, an Html Element, Html Fragment.
	/// 
	/// Typically the distinction is found by considering the state
	/// of it's properties.
	/// 
	/// Html Text: will have a Value that is a string, but no children,
	/// or attributes.
	/// 
	/// Html Element: will have a Name, which is the tag name of the Element
	/// (and only potentially have Attributes and Children, and the Value is
	/// meaningless to an Element).
	/// 
	/// Html Fragment: will may have Children but no Name, Attributes, or Value.
	/// So, a IHtml instance without information in the form of Name, Value,
	/// Children or Attributes is considered a Fragment.
	/// 
	/// The state of these properties will influence the values returned by
	/// the boolean properties that signal if the instance is a Text Node,
	/// Html Element or Html Fragment.
	/// </summary>
	public interface IHtml : IFragment, IHtmlElement, IHtmlText, IHtmlRenderable
	{
		bool IsText { get; }
		bool IsFragment { get; }
		bool IsElement { get; }

		bool HasChildren { get; }
		bool HasAttributes { get; }

		TextWriter Write(TextWriter tw);
		TextWriter Write(TextWriter tw, bool indent, int level, string tab, string indenting);
	}

	/// <summary>
	/// An IHtmlElement has a Name (the tag name), and potentially Attributes
	/// and Children.
	/// </summary>
	public interface IHtmlElement : IFragment
	{
		IDictionary<string, string> Attributes { get; set; }

		string Name { get; set; }
	}

	/// <summary>
	/// An IFragment has a IList of Children (potentially 0 children, but a
	/// list nontheless).
	/// </summary>
	public interface IFragment
	{
		IList<IHtml> Children { get; set; }
	}

	/// <summary>
	/// An IHtmlText instance is nothing more than object for which ToString()
	/// can be called, and produces a text value that can be included in an
	/// Html document.
	/// </summary>
	public interface IHtmlText
	{
		object Value { get; set; }
	}
}
