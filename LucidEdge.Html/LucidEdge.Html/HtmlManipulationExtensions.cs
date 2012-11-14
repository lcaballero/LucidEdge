using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Create an element from a Tag, ID, and Classes
using CreateTag = System.Func<string, string, string, LucidEdge.Html.IHtml>;
// Create an element from Tag, Value, Attributes, Children
using CreateElement = System.Func<string, object, System.Collections.Generic.Dictionary<string, string>, System.Collections.Generic.IList<LucidEdge.Html.IHtml>, LucidEdge.Html.IHtml>;


namespace LucidEdge.Html
{
	/// <summary>
	/// This class hosts a large number of extension functions that create and
	/// manipulate instances of IHtml.
	/// </summary>
	public static class HtmlManipulationExtensions
	{
		private static readonly char[] TAG_DELIMS = new[] { '#', '.', ' ' };

		/// <summary>
		/// This parses from the string 's' the tag from a tag description, which
		/// can have a syntax which includes IDs and Classes, for instance:
		/// 
		/// div
		/// div#my-id
		/// div#my-id.my-class
		/// div.my-class#my-id.another-class
		/// .a-class
		/// #an-id
		/// 
		/// </summary>
		/// <param name="s">
		/// A tag definition that includes possible a id and classes.
		/// </param>
		/// <param name="default">
		/// If no tag can be parsed from this method then it returns the @default
		/// value, and or "div" if non is provided.
		/// </param>
		/// <returns>
		/// The tag parsed form the tag description provided as 's'.
		/// </returns>
		public static string ParseTag(this string s, string @default = "div")
		{
			s = s ?? "";
			int n = s.IndexOfAny(TAG_DELIMS);

			return
				n > 0 ? s.Substring(0, n) :		// has delim, but not at start of string
				n == -1 && s != "" ? s :		// no delim, and s is not null or empty
				@default;						// delim is at 0 or no delim
		}

		/// <summary>
		/// Parses the classes from the tag definition provided as 's'.
		/// </summary>
		/// <param name="s">
		/// A tag definition in the format outlined from ParseTag.
		/// </param>
		/// <returns>
		/// A space seperated string of classes as parsed from the tag description.
		/// </returns>
		public static string ParseClasses(this string s)
		{
			s = s ?? "";

			int hash_1 = s.IndexOf('#');
			int class_1 = s.IndexOf('.', 0);
			int class_2 = s.IndexOf('.', hash_1 == -1 ? 0 : hash_1);

			return
				class_1 == -1 ? "" :
				class_1 < hash_1 && class_2 == -1 ? s.Substring(class_1 + 1, hash_1 - class_1 - 1) :
				class_1 > hash_1 ? s.Substring(class_1 + 1).Replace('.', ' ') :
				class_2 > -1 && hash_1 != -1 ?
					string.Concat(
							s.Substring(class_1 + 1, hash_1 - class_1 - 1), " ",
							s.Substring(class_2 + 1))
						.Replace('.', ' ') :
				"";
		}

		/// <summary>
		/// Parses the id from the tag definition provided as 's'.
		/// </summary>
		/// <param name="s">
		///  A tag definition in the format outlined from ParseTag.
		/// </param>
		/// <returns>
		/// An string representing the id parsed from the string or an empty
		/// string if no id is found in the tag definition.
		/// </returns>
		public static string ParseId(this string s)
		{
			s = s ?? "";

			int hash = s.IndexOf('#');
			int @class = s.IndexOf('.', hash == -1 ? 0 : hash);

			return
				hash == -1 ? "" :											// No Ids
				@class > -1 ? s.Substring(hash + 1, @class - hash - 1) :	// Ids and class(es)
				@class == -1 ? s.Substring(hash + 1) :						// Ids, no class(es)
				"";															// Default
		}

		/// <summary>
		/// This lambda is used to create and Element/Tag from strings
		/// representing tag, id, and classes.
		/// </summary>
		public readonly static CreateTag DefaultToTag =
			(tag, id, classes) =>
			new Html { Name = tag }
					.AttrIf(!string.IsNullOrEmpty(classes), () => new[] { "class", classes })
					.AttrIf(!string.IsNullOrEmpty(id), () => new[] { "id", id });

		/// <summary>
		/// This lambda is used to create an Element from values that represent
		/// a tag, text string, attributes, and/or children; however, each of
		/// these values maybe null producing an Html instance that represents
		/// a Fragment as defined in IHtml.
		/// </summary>
		public readonly static CreateElement DefaultToElement =
			(tag, value, attributes, children) =>
				new Html
				{
					Name = tag,
					Value = value,
					Attributes = attributes,
					Children = children
				};

		/// <summary>
		/// This function can override the default behavior provided by DefaultToTag.
		/// </summary>
		public static CreateTag CreateTag = null;

		/// <summary>
		/// This function can override the default behavior provided by DefaultToElement.
		/// </summary>
		public static CreateElement CreateElement = null;

		/// <summary>
		/// Determines the correct creation function to use for the creation of a Tag.
		/// </summary>
		/// <param name="html">
		/// A possibly null value or a function to create tags.
		/// </param>
		/// <returns>
		/// The proper function to use for tag creation.
		/// </returns>
		private static CreateTag ActiveToTag(CreateTag html)
		{
			return
			html != null ? html :
			CreateTag != null ? CreateTag :
			DefaultToTag;
		}

		private static CreateElement ActiveToElement(CreateElement html)
		{
			return
			html != null ? html :
			CreateElement != null ? CreateElement :
			DefaultToElement;
		}

		public static IHtml ToNode(this string tag, string id, string classes, CreateTag html = null)
		{
			return ActiveToTag(html)(tag, id, classes);
		}

		private static IHtml ToNode(this object obj)
		{
			return
			obj is string ?
				ActiveToElement(null)(null, obj, null, null) :
			obj is IHtml ?
				((IHtml)obj) :
				ActiveToElement(null)(null, null, null, null);
		}

		public static IEnumerable<IHtml> ToNodes(this object n)
		{
			return
			n == null ?
				new List<IHtml>() :
			n is int || n is double || n is DateTime || n is bool ?
				(n.ToString()).ToNodes() :
			n is string ?
				(n as string).ToNode().Lift() :
			n is IEnumerable<string> ?
				(n as IEnumerable<string>).SelectMany(s => s.ToNodes()) :
			n is IHtml ?
				(n as IHtml).ToNode().Lift() :
			n is IEnumerable<IHtml> ?
				(n as IEnumerable<IHtml>) :
			n is IHtmlRenderable ?
				(n as IHtmlRenderable).ToHtml().Lift() :
			n is IEnumerable<IHtmlRenderable> ?
				(n as IEnumerable<IHtmlRenderable>).Select(m => m.ToHtml()) :
			// Begin a single level, nesting of IEnumerables
			n is IEnumerable<IEnumerable<IHtml>> ?
				(n as IEnumerable<IEnumerable<IHtml>>).SelectMany(m => m) :
			n is IEnumerable<IEnumerable<IHtmlRenderable>> ?
				(n as IEnumerable<IEnumerable<IHtmlRenderable>>).SelectMany(m => m.ToNodes()) :
			n.ToNode().Lift();
		}

		public static IHtml ToFragment(this string s)
		{
			return s.ToNode();
		}

		/// <summary>
		/// Sets the tag name of the element, parsing the given tag name
		/// expression for ids and classes specified as css selectors.
		/// </summary>
		/// <example>
		/// div.myclass#myid
		/// </example>
		public static IHtml ParseTagName(this string tagDef)
		{
			return tagDef.ParseTag().ToNode(tagDef.ParseId(), tagDef.ParseClasses());
		}

		/// <summary>
		/// Add() can take a number of types that are either instances of IHtml,
		/// collections of IHtml, or collections of things that can be turned into
		/// instances of IHtml.
		/// 
		/// This set of types and things includes these:
		///		string
		///		bool | int | double | DateTime
		///		IHtml
		///		IEnumerable[Html]
		///		IEnumerable[IEnumerable[Html]]
		///		IHtmlRenderable
		///		IEnumerable[IHtmlRenderable]
		///		IEnumerable[IEnumerable[IHtmlRenderable]]
		/// </summary>
		/// <param name="d">
		/// The target IHtml instance to add the given children.
		/// </param>
		/// <param name="children">
		/// The children which can be of the types provided.
		/// </param>
		/// <returns>
		/// Returns the IHtml instance provided.
		/// </returns>
		public static IHtml Add(this IHtml d, params object[] children)
		{
			var kids = 
				children == null || children.Length == 0
					? d.Children
					: children.SelectMany(n => n.ToNodes());

			d.Children =
				d.Children == null && kids == null ? null :
				d.Children == null && kids != null ? kids.ToList() :
				d.Children != null && kids == null ? d.Children :
				d.Children != null && kids != null ? d.Children.Concat(kids).ToList() :
				null;

			return d;
		}

		private static IDictionary<string,string> Attr(this IDictionary<string,string> a, object[] atts)
		{
			return
			(0).To(atts == null ? 0 : atts.Length)
				.Where(n => n % 2 == 0)
				.Aggregate(
					a ?? new Dictionary<string,string>(),
					(acc, n) => {
						acc.Add(atts[n].ToString(), atts[n + 1].ToString());
						return acc;
					});
		}

		/// <summary>
		/// Adds the attributes provided to the IHtml instance.
		/// </summary>
		/// <param name="d">
		/// The target IHtml instance to modify by adding the Atts provided.
		/// </param>
		/// <param name="atts">
		/// The ToString value from each attribute is added to the IHtml instance.
		/// </param>
		/// <returns>
		/// The modified IHtml instance.
		/// </returns>
		public static IHtml Attr(this IHtml d, params object[] atts)
		{
			d.Attributes = d.Attributes.Attr(atts);
			return d;
		}

		public static IHtml AddClass(this IHtml d, params string[] classes)
		{
			string c = null;

			d.Attributes = d.Attributes ?? new Dictionary<string, string>();

			d.Attributes["class"] =
				(d.Attributes.TryGetValue("class", out c))
				? c.ActiveClass(classes).Trim()
				: string.Join(" ", classes);

			return d;
		}

		public static string ActiveClass(this string current, params string[] classes)
		{
			return
			classes.Aggregate(
				current,
				(acc, c) =>
					(" " + current + " ").Replace(c, "").Trim())
					+ " "
					+ string.Join(" ", classes);
		}

		#region 1
		public static IHtml Attr(this string d, params object[] atts)
		{
			return d.ParseTagName().Attr(atts);
		}

		public static IHtml AddClass(this string d, params string[] classes)
		{
			return d.ParseTagName().AddClass(classes);
		}

		public static IHtml Add(this string d, params object[] children)
		{
			return d.ParseTagName().Add(children);
		}
		#endregion 1

		#region Add If (string)
		public static IHtml AddIf(this string n, bool condition, Func<object[]> trueFn, Func<object[]> falseFn = null)
		{
			return
			condition ? n.Add(trueFn()) :
			falseFn == null ? n.ParseTagName() :
			n.Add(falseFn());
		}

		public static IHtml AddIf(this string n, bool condition, Func<object> trueFn, Func<object> falseFn = null)
		{
			return
			condition ? n.ParseTagName().Attr(trueFn()) :
			falseFn == null ? n.ParseTagName() :
			n.ParseTagName().Attr(falseFn());
		}

		public static IHtml AttrIf(this string n, bool condition, Func<object[]> trueFn, Func<object[]> falseFn = null)
		{
			return
			condition ? n.ParseTagName().Attr(trueFn()) :
			falseFn == null ? n.ParseTagName() :
			n.ParseTagName().Attr(falseFn());
		}
		#endregion Add If (string)

		#region Add Class If (string)
		public static IHtml AddClassIf(this string n, bool condition, Func<string> trueFn, Func<string> falseFn = null)
		{
			return
				condition ? n.ParseTagName().AddClass(trueFn()) :
				falseFn == null ? n.ParseTagName() :
				n.ParseTagName().AddClass(falseFn());
		}
		#endregion Add Class If (string)

		#region Add If (Node)

		public static IHtml AddIf(this IHtml n, bool condition, Func<object[]> trueFn, Func<object[]> falseFn = null)
		{
			return
			condition ? n.Add(trueFn()) :
			falseFn == null ? n :
			n.Add(falseFn());
		}

		public static IHtml AddIf(this IHtml n, bool condition, Func<object> trueFn, Func<object> falseFn = null)
		{
			return
			condition ? n.Add(trueFn()) :
			falseFn == null ? n :
			n.Add(falseFn());
		}

		public static IHtml AttrIf(this IHtml n, string condition, Func<object[]> trueFn, Func<object[]> falseFn = null)
		{
			return n.AttrIf(!string.IsNullOrEmpty(condition), trueFn, falseFn);
		}

		public static IHtml AttrIf(this IHtml n, bool condition, Func<object[]> trueFn, Func<object[]> falseFn = null)
		{
			return
			condition ? n.Attr(trueFn()) :
			falseFn == null ? n :
			n.Attr(falseFn());
		}
		#endregion Add If (Node)
	}
}
